import BackToTheFuture from 0xf8d6e0586b0a20c7

pub fun main(acct: Address): Int{

        let state = getAccount(acct).getCapability(/public/Statepub3).borrow<&BackToTheFuture.State>()?? panic ("we couldnt get state")

        return state.Plutonium
}