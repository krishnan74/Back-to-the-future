



pub contract BackToTheFuture{


    pub resource State{

        pub var Name: String
        pub var Plutonium: Int
        pub var Health: Int
        pub var Missions: [String]


        init(_name: String){

            self.Name = _name
            self.Plutonium = 0
            self.Health = 0
            self.Missions =[]

        }
        
        
        pub fun GetName() : String
        {
            return self.Name
        }

        pub fun newGame(name: String){
            self.Plutonium = 0
            self.Health = 100
        } 

        pub fun addPlutonium(_P: Int){
            self.Plutonium = self.Plutonium + _P
        } 

        pub fun updateHealth(_value: Int){
            self.Health = self.Health - _value
        }

        pub fun updateMission(mission: String){
            self.Missions.append(mission)
        }
    }

    pub fun createState(name: String): @State{
        return <- create State(_name: name)
    }
}