namespace PrayerScheduler;

public class PrayerScheduler
{

    
    public int NumDailyPrayers => DailyPrayers.Count;
    
    public int NumNonDailyPrayers => nonDailyPrayers.Count;

    public List<Prayer> DailyPrayers { get; } = new();

    private Queue<Prayer> nonDailyPrayers = new(); 
    public List<Prayer> NonDailyPrayers
    {
        get
        {
            return nonDailyPrayers.ToList();
        }
    }

    public List<Prayer> AnsweredPrayers { get; } = new();

    public PrayerScheduler()
    {
    }

    // TODO
    public void AddPrayer(Prayer prayer)
    {
        if (DailyPrayers.Find(p => p.ID == prayer.ID) is not null || NonDailyPrayers.Find(p => p.ID == prayer.ID) is not null || AnsweredPrayers.Find(p => p.ID == prayer.ID) is not null)
        {
            throw new DuplicateIDException();
        }
        // if answered
        // add it to answered
        if (prayer.IsAnswered)
        {
            AnsweredPrayers.Add(prayer);
            return;
        }
        //if unanswered
        // if daily, add to dailys
        if (prayer.IsDaily)
        {
            DailyPrayers.Add(prayer);
            return;
        }
        else
        {
            nonDailyPrayers.Enqueue(prayer);
            return;
        }

    }

    public void AnswerPrayer(int id)
    {
        var prayer = DailyPrayers.Find(p => p.ID == id);
        if(prayer is not null)
        {
            prayer.IsAnswered = true;
            DailyPrayers.Remove(prayer);
            AnsweredPrayers.Add(prayer);
            return;
        }
    
        for(int i = 0; i < nonDailyPrayers.Count+1; i++)
        {
            var Currentnode = nonDailyPrayers.Dequeue();
            if (Currentnode.ID == id)
            {
                Currentnode.IsAnswered = true;
                AnsweredPrayers.Add(Currentnode);
            }
            else
            {
                nonDailyPrayers.Enqueue(Currentnode);
            }

        }

    }

    // TODO
    public List<Prayer> GetPrayers(int numPrayers)
    {
        List<Prayer> prayers = [.. DailyPrayers];
        numPrayers -= DailyPrayers.Count;
        //numPrayers = Math.Min(numPrayers, nonDailyPrayers.Count);
        while (numPrayers > 0)
        {
            var nondailyprayer = nonDailyPrayers.Dequeue();
            prayers.Add(nondailyprayer);
            nonDailyPrayers.Enqueue(nondailyprayer);
            numPrayers--;
        }
        foreach(var p in prayers)
        {
            p.LastPrayed = DateTime.Now;
        }

        return prayers;
    }

}


