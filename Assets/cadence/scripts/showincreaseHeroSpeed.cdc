

import BackToTheFuture from 0xf8d6e0586b0a20c7

pub fun main(): Int{

        let state = getAccount(0xf8d6e0586b0a20c7).getCapability(/public/Statepub)   
                        .borrow<&BackToTheFuture.State>()
                        ?? panic ("we couldnt get state")

        return state.increaseHeroSpeed

}