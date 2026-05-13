public static class PlayAnalyzer
{
    public static string AnalyzeOnField(int shirtNum)
    {
        return shirtNum switch
        {
            1 => "goalie",
            2 => "left back",
            3 or 4 => "center back",
            5 => "right back",
            6 or 7 or 8 => "midfielder",
            9 => "left wing",
            10 => "striker",
            11 => "right wing",
            _ => "UNKNOWN",
        };
    }

    public static string AnalyzeOffField(object report)
    {
        if (report is int supporters)
        {
            return $"There are {supporters} supporters at the match.";
        }
        else if (report is string announcemnet)
        {
            return announcemnet;
        }
        else if (report is Injury injury)
        {
            return $"Oh no! {injury.GetDescription()} Medics are on the field.";
        }
        else if (report is Incident incident)
        {
            return incident.GetDescription();
        }
        else if (report is Manager manager)
        {
            var res = manager.Name;

            if (manager.Club != null)
            {
                res += $" ({manager.Club})";
            }

            return res;
        }

        return string.Empty;
    }
}
