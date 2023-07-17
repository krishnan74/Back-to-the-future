import BackToTheFuture from GAME_DEPLOY_ACCOUNT

pub fun main(acct: Address): Int{

        let state = getAccount(acct).getCapability(/public/Statepub3).borrow<&BackToTheFuture.State>()?? panic ("we couldnt get state")

        return state.Plutonium
}