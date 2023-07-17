import BackToTheFuture from 0xf8d6e0586b0a20c7

transaction {
    prepare(acct: AuthAccount) {

        let ref <- acct.load<@BackToTheFuture.State>(from: /storage/State)!     

        ref.addFivePlutonium()

        acct.save(<-ref, to: /storage/State)
    
    }

    execute{
        log("Updated Plutonium!")
    }
}

