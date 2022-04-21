
public static class LevelConfig 
{

    private static int activeLevel;
    private static float minEnemyMovementSpeed;
    private static float maxEnemyMovementSpeed;
    private static float minEnemyFireSpeed;
    private static float maxEnemyFireSpeed;
    private static float minEnemySpawnTime;
    private static float maxEnemySpawnTime;
    private static float minEnemyLaserMoveSpeed;
    private static float maxEnemyLaserMoveSpeed;
    private static int levelCompleted;

    public static int ActiveLevel { get => activeLevel; set => activeLevel = value; }
    public static float MinEnemyMovementSpeed { get => minEnemyMovementSpeed; set => minEnemyMovementSpeed = value; }
    public static float MaxEnemyMovementSpeed { get => maxEnemyMovementSpeed; set => maxEnemyMovementSpeed = value; }
    public static float MinEnemyFireSpeed { get => minEnemyFireSpeed; set => minEnemyFireSpeed = value; }
    public static float MaxEnemyFireSpeed { get => maxEnemyFireSpeed; set => maxEnemyFireSpeed = value; }
    public static float MinEnemySpawnTime { get => minEnemySpawnTime; set => minEnemySpawnTime = value; }
    public static float MaxEnemySpawnTime { get => maxEnemySpawnTime; set => maxEnemySpawnTime = value; }
    public static float MinEnemyLaserMoveSpeed { get => minEnemyLaserMoveSpeed; set => minEnemyLaserMoveSpeed = value; }
    public static float MaxEnemyLaserMoveSpeed { get => maxEnemyLaserMoveSpeed; set => maxEnemyLaserMoveSpeed = value; }
    public static int LevelCompleted { get => levelCompleted; set => levelCompleted = value; }



    public static void SetLevel() {

        SetMovementSpeed();
        SetEnemyFireSpeed();
        SetEnemySpawnTime();
        SetEnemyLaserMoveSpeed();
        SetLevelCompletedScore();
    }

    public static void SetMovementSpeed() {

        float tabanSpeed = 0, tavanSpeed = 0;

        if (activeLevel < 2) { tabanSpeed = 1; tavanSpeed = 3; }
        else if (activeLevel >= 2 && activeLevel < 4) { tabanSpeed = 2; tavanSpeed = 4; }
        else if (activeLevel >= 4 && activeLevel < 6) { tabanSpeed = 3; tavanSpeed = 5; }
        else if (activeLevel >= 6 && activeLevel < 8) { tabanSpeed = 4; tavanSpeed = 6; }
        else if (activeLevel >= 8 && activeLevel < 50) { tabanSpeed = 5; tavanSpeed = 7; }

        minEnemyMovementSpeed = (tabanSpeed + ((float)activeLevel / 100f));
        maxEnemyMovementSpeed = (tavanSpeed + ((float)activeLevel / 100f));
    }

    public static void SetEnemyFireSpeed() {



        minEnemyFireSpeed = minEnemyMovementSpeed + 2;
        maxEnemyFireSpeed = maxEnemyMovementSpeed + 2;
    }

    public static void SetEnemySpawnTime() {


        minEnemySpawnTime = 2;
        maxEnemySpawnTime = 4;
    }

    public static void SetEnemyLaserMoveSpeed() {

        minEnemyLaserMoveSpeed = maxEnemyMovementSpeed + 1;
        maxEnemyLaserMoveSpeed = maxEnemyMovementSpeed + 3;
    }

    public static void SetLevelCompletedScore() {

        if (activeLevel < 10) { levelCompleted = (10 * activeLevel); }
        else if (activeLevel >= 10 && activeLevel < 15) { levelCompleted = (15 * activeLevel); }
        else if (activeLevel >= 15 && activeLevel < 20) { levelCompleted = (20 * activeLevel); }
        else if (activeLevel >= 20 && activeLevel < 30) { levelCompleted = (25 * activeLevel); }
        else if (activeLevel >= 30 && activeLevel < 50) { levelCompleted = (30 * activeLevel); }


    }


}
