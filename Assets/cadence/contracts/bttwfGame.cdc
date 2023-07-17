

pub contract BackToTheFuture{


    pub resource State{

        pub var Name: String
        pub var Plutonium: Int

        //powerups
        pub var HealthIncrementCollect: Int
        pub var PowerIncrement: Int
        pub var DamageIncrement: Int
        pub var increasedPlutoFromEnemy: Int
        pub var increasedPlutoSpawn: Int
        pub var increasedHealthSpawn: Int
        pub var slowEnemySpeed: Int
        pub var increaseHeroSpeed: Int
        pub var lessDamageFromEnemy: Int

        init(_name: String){

            self.Name = _name
            self.Plutonium = 0

            self.HealthIncrementCollect = 0
            self.PowerIncrement = 0
            self.DamageIncrement = 0
            self.increasedPlutoFromEnemy = 0
            self.increasedPlutoSpawn = 0
            self.increasedHealthSpawn = 0
            self.slowEnemySpeed = 0
            self.increaseHeroSpeed = 0
            self.lessDamageFromEnemy = 0

        }
        
        
        pub fun GetName() : String
        {
            return self.Name
        }

        pub fun newGame(name: String){
            self.Plutonium = 0
        } 

        pub fun addSinglePlutonium(){
            self.Plutonium = self.Plutonium + 1
        } 
        pub fun addFivePlutonium(){
            self.Plutonium = self.Plutonium + 5
        } 
        pub fun addTenPlutonium(){
            self.Plutonium = self.Plutonium + 10
        } 


        //POWERUPS -- add/sub

        //healthCollect
        pub fun inc_HealthCollect(){
            self.HealthIncrementCollect = self.HealthIncrementCollect + 1
        }
        pub fun dec_HealthCollect(){
            self.HealthIncrementCollect = self.HealthIncrementCollect - 1
        }

        //powerInc
        pub fun inc_PowerInc(){
            self.PowerIncrement = self.PowerIncrement + 1
        }
        pub fun dec_PowerInc(){
            self.PowerIncrement = self.PowerIncrement - 1
        }

        //DamageIncrement
        pub fun inc_DamageInc(){
            self.DamageIncrement = self.DamageIncrement + 1
        }
        pub fun dec_DamageInc(){
            self.DamageIncrement = self.DamageIncrement - 1
        }

        //self.increasedPlutoFromEnemy
        pub fun inc_PlutoEnemy(){
            self.increasedPlutoFromEnemy = self.increasedPlutoFromEnemy + 1
        }
        pub fun dec_PlutoEnemy(){
            self.increasedPlutoFromEnemy = self.increasedPlutoFromEnemy - 1
        }

        //self.increasedPlutoSpawn
        pub fun inc_PlutoSpawn(){
            self.increasedPlutoSpawn = self.increasedPlutoSpawn + 1
        }
        pub fun dec_PlutoSpawn(){
            self.increasedPlutoSpawn = self.increasedPlutoSpawn - 1
        }

        //increasedHealthSpawn
        pub fun inc_HealthSpawn(){
            self.increasedHealthSpawn = self.increasedHealthSpawn + 1
        }
        pub fun dec_HealthSpawn(){
            self.increasedHealthSpawn = self.increasedHealthSpawn - 1
        }

        //slowEnemySpeed
        pub fun inc_SlowEnemy(){
            self.slowEnemySpeed = self.slowEnemySpeed + 1
        }
        pub fun dec_SlowEnemy(){
            self.slowEnemySpeed = self.slowEnemySpeed - 1
        }
        
        //increaseHeroSpeed
        pub fun inc_HeroSpeedInc(){
            self.increaseHeroSpeed = self.increaseHeroSpeed + 1
        }
        pub fun dec_HeroSpeedInc(){
            self.increaseHeroSpeed = self.increaseHeroSpeed - 1
        }
        
        //lessDamageFromEnemy
        pub fun inc_lessDamageInc(){
            self.lessDamageFromEnemy = self.lessDamageFromEnemy + 1
        }
        pub fun dec_lessDamageInc(){
            self.lessDamageFromEnemy = self.lessDamageFromEnemy - 1
        }

        
    }

    pub fun createState(name: String): @State{
        return <- create State(_name: name)
    }
}