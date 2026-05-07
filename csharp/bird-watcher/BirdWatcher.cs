class BirdCount(int[] birdsPerDay)
{
    private int[] birdsPerDay = birdsPerDay;

    public static int[] LastWeek() => [0, 2, 5, 3, 7, 8, 4];

    public int Today() => birdsPerDay[^1];

    public void IncrementTodaysCount() => birdsPerDay[^1]++;

    public bool HasDayWithoutBirds()
    {
        foreach (var item in birdsPerDay)
        {
            if (item <= 0) return true;
        }

        return false;
    }

    public int CountForFirstDays(int numberOfDays)
    {
        var sum = 0;

        foreach (var item in birdsPerDay[..numberOfDays])
        {
            sum += item;    
        }
        
        return sum;
    }

    public int BusyDays()
    {
        var cnt = 0;

        foreach (var item in birdsPerDay)
        {
            if (item >= 5) cnt++;
        }

        return cnt;
    }
}
