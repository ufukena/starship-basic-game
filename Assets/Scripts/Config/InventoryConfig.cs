public static class InventoryConfig 
{
    
    private static int movementInventory;
    private static int fireSpeedInventory;
    private static int laserSpeedInventory;
    private static int bombPieceInventory;
    //private static int time;

    public static int MovementInventory { get => movementInventory; set => movementInventory = value; }
    public static int FireSpeedInventory { get => fireSpeedInventory; set => fireSpeedInventory = value; }
    public static int LaserSpeedInventory { get => laserSpeedInventory; set => laserSpeedInventory = value; }
    public static int BombPieceInventory { get => bombPieceInventory; set => bombPieceInventory = value; }

    //public static int Time { get => time; set => time = value; }


    public static void Reset() {

        movementInventory = 0;
        fireSpeedInventory = 0;
        laserSpeedInventory = 0;
        //time = 1;
        bombPieceInventory = 10;
    }   


    public static void SetMovementSpeed() {

        if (movementInventory == 10)
            return;

        int temp_data = 0;

        switch (movementInventory + 1) {

            case 1: temp_data = 5; break;
            case 2: temp_data = 5; break;
            case 3: temp_data = 10; break;
            case 4: temp_data = 10; break;
            case 5: temp_data = 10; break;
            case 6: temp_data = 10; break;
            case 7: temp_data = 20; break;
            case 8: temp_data = 20; break;
            case 9: temp_data = 20; break;
            case 10: temp_data = 30; break;

        }

        if (PlayerConfig.ScoreCurrent < temp_data)
            return;

        movementInventory += 1;
        PlayerConfig.MovementSpeed += 0.5f;
        PlayerConfig.ScoreCurrent -= temp_data;



    }

    public static void SetFireSpeed() {

        if (fireSpeedInventory == 10)
            return;

        int temp_data = 0;

        switch (fireSpeedInventory + 1) {

            case 1: temp_data = 5; break;
            case 2: temp_data = 5; break;
            case 3: temp_data = 10; break;
            case 4: temp_data = 10; break;
            case 5: temp_data = 10; break;
            case 6: temp_data = 10; break;
            case 7: temp_data = 20; break;
            case 8: temp_data = 20; break;
            case 9: temp_data = 20; break;
            case 10: temp_data = 30; break;

        }

        if (PlayerConfig.ScoreCurrent < temp_data)
            return;

        fireSpeedInventory += 1;
        PlayerConfig.FireSpeed -= 0.2f;
        PlayerConfig.ScoreCurrent -= temp_data;

    }

    public static void SetLaserSpeed() {
        
        if (laserSpeedInventory == 10)
            return;

        int temp_data = 0;

        switch (laserSpeedInventory+1) {

            case 1: temp_data = 5; break;
            case 2: temp_data = 5; break;
            case 3: temp_data = 10; break;
            case 4: temp_data = 10; break;
            case 5: temp_data = 10; break;
            case 6: temp_data = 10; break;
            case 7: temp_data = 20; break;
            case 8: temp_data = 20; break;
            case 9: temp_data = 20; break;
            case 10: temp_data = 30; break;

        }

        if (PlayerConfig.ScoreCurrent < temp_data)
            return;

        laserSpeedInventory += 1;
        PlayerConfig.LaserSpeed += 0.2f;
        PlayerConfig.ScoreCurrent -= temp_data;

    }

    public static void SetBombPiece() {

        if (bombPieceInventory == 1)
            return;

        int temp_data = 0;

        switch (bombPieceInventory - 1) {

            case 10: temp_data = 5; break;
            case 9: temp_data = 5; break;
            case 8: temp_data = 5; break;
            case 7: temp_data = 10; break;
            case 6: temp_data = 10; break;
            case 5: temp_data = 10; break;
            case 4: temp_data = 10; break;
            case 3: temp_data = 20; break;
            case 2: temp_data = 20; break;
            case 1: temp_data = 30; break;
                                  
        }

        if (PlayerConfig.ScoreCurrent < temp_data)
            return;

        bombPieceInventory -= 1;        
        PlayerConfig.ScoreCurrent -= temp_data;

    }

    public static void SetWeapon() {
              
        if (PlayerConfig.ScoreCurrent < 10)
            return;
               
        PlayerConfig.ScoreCurrent -= 10;

        PlayerConfig.WeaponCurrent += 20;

    }

    



}
