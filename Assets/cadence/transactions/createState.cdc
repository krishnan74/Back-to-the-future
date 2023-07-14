import BackToTheFuture from 0xf8d6e0586b0a20c7

transaction {
    prepare(acct: AuthAccount) {
        acct.save<-(BackToTheFuture.createState, to: /storage/state)
        // panic("Could not load counter resource")
    }
}
