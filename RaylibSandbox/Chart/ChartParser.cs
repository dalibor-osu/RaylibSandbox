using Serilog;

namespace RaylibSandbox.Chart;

public static class ChartParser
{
    public static List<ChartData> ParseAll(string path)
    {
        List<ChartData> charts = new();
        foreach (string directory in Directory.GetDirectories(path))
        {
            Log.Debug("Loading chart at {Path}", directory);
            var chart = Parse(directory);
            if (chart != null)
            {
                charts.Add(chart);
            }
        }

        return charts;
    }
    
    public static ChartData? Parse(string path)
    {
        try
        {
            string[] lines = File.ReadAllLines(Path.Combine(path, "data.txt"));
            var songData = ParseSongData(lines);
            var notes = ParseNotes(lines);
            
            return new ChartData
            {
                SongData = songData,
                Notes = notes
            };
        }
        catch (Exception e)
        {
            Log.Error(e, "Failed to parse chart at {Path}", path);
            return null;
        }
    }
    
    private static SongData ParseSongData(string[] lines)
    {
        string name = lines.First(x => x.Contains("NAME:")).Split("NAME:")[1].Trim();
        string artist = lines.First(x => x.Contains("ARTIST:")).Split("ARTIST:")[1].Trim();
        float bpm = float.Parse(lines.First(x => x.Contains("BPM:")).Split("BPM:")[1].Trim());
        int offset = int.Parse(lines.First(x => x.Contains("OFFSET:")).Split("OFFSET:")[1].Trim());
        int length = int.Parse(lines.First(x => x.Contains("LENGTH:")).Split("LENGTH:")[1].Trim());

        return new SongData
        {
            Name = name,
            Artist = artist,
            BPM = bpm,
            Offset = offset,
            Length = length
        };
    }
    
    private static List<NoteInfo> ParseNotes(string[] lines)
    {
        List<NoteInfo> notes = new();
        int startIndex = lines.ToList().FindIndex(x => x.Contains("[NOTES]")) + 1;
        foreach (string line in lines.Skip(startIndex + 1))
        {
            if (string.IsNullOrEmpty(line))
            {
                continue;
            }
            
            string[] parts = line.Split(' ');
            
            if (!int.TryParse(parts[0], out int time))
            {
                Log.Error("Error on line {Line}. Failed to parse time.", line);
            }
            
            if (!int.TryParse(parts[1], out int lane))
            {
                Log.Error("Error on line {Line}. Failed to parse lane.", line);
            }
            
            notes.Add(new NoteInfo{Lane = lane, Time = time});
        }

        return notes;
    }
}