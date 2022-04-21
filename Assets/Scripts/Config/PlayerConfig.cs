public static class PlayerConfig 
{

    private static int scoreCurrent;
    private static int weaponCurrent;
    private static int healthCurrent;
    private static int weaponPoint;
    private static int healthPoint;

    private static float movementSpeed;
    private static float fireSpeed;
    private static float laserSpeed;
    private static int bombPiece;


    public static int ScoreCurrent { get => scoreCurrent; set => scoreCurrent = value; }
    public static int WeaponCurrent { get => weaponCurrent; set => weaponCurrent = value; }
    public static int HealthCurrent { get => healthCurrent; set => healthCurrent = value; }
    public static int WeaponPoint { get => weaponPoint; set => weaponPoint = value; }
    public static int HealthPoint { get => healthPoint; set => healthPoint = value; }
    public static float MovementSpeed { get => movementSpeed; set => movementSpeed = value; }
    public static float FireSpeed { get => fireSpeed; set => fireSpeed = value; }
    public static float LaserSpeed { get => laserSpeed; set => laserSpeed = value; }
    public static int BombPiece { get => bombPiece; set => bombPiece = value; }


    public static void Reset() {


        scoreCurrent = 0;
        weaponCurrent = 30;
        healthCurrent = 50;

        movementSpeed = 2f;
        fireSpeed = 2f;
        laserSpeed = 4f;
        bombPiece = 10;

        weaponPoint = weaponCurrent;
        healthPoint = healthCurrent;

    }

}
