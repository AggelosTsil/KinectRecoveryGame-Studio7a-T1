using System.Collections.Generic;

public static class PatientSaveConverter
{

    // Patient Save Data

    public static PatientSaveData ToSave(Patient p)
    {
        PatientSaveData save = new PatientSaveData();


        save.Name = p.Name;
        save.Surname = p.Surname;
        save.Number = p.Number;
        save.Email = p.email;

        save.DoctorName = p.Name_Doctor;
        save.DoctorSurname = p.Surname_Doctor;
        save.DoctorNumber = p.Number_Doctor;
        save.DoctorEmail = p.email_Doctor;

        save.Diagnosis = p.Diagnosis;
        save.Notes = p.Notes;
        save.Sessions = p.Sessions;

        foreach (var s in p.GamePlaylist)
        {
            save.Playlist.Add(new GameSessionSaveData()
            {
                GameID = s.GamePrefab.Gameid,
                ThemeIndex = s.SelectedThemeIndex,
                Duration = s.durationSeconds,
                Reps = s.Reps,
                Difficulty = s.Difficulty
            });
        }

        return save;
    }

    // Patient Save Data
    public static void ApplySaveToPatient(
        Patient patient,
        PatientSaveData save,
        List<Game> gameDatabase)
    {
        patient.Name = save.Name;
        patient.Surname = save.Surname;
        patient.Number = save.Number;
        patient.email = save.Email;

        patient.Name_Doctor = save.DoctorName;
        patient.Surname_Doctor = save.DoctorSurname;
        patient.Number_Doctor = save.DoctorNumber;
        patient.email_Doctor = save.DoctorEmail;

        patient.Diagnosis = save.Diagnosis;
        patient.Notes = save.Notes;
        patient.Sessions = save.Sessions;

        patient.GamePlaylist.Clear();

        foreach (var s in save.Playlist)
        {
            Game game = gameDatabase.Find(g => g.Gameid == s.GameID);

            if (game == null) continue;

            GameSession session = new GameSession();

            session.GamePrefab = game;
            session.SelectedThemeIndex = s.ThemeIndex;
            session.durationSeconds = s.Duration;
            session.Reps = s.Reps;
            session.Difficulty = s.Difficulty;

            patient.GamePlaylist.Add(session);
        }
    }
}
