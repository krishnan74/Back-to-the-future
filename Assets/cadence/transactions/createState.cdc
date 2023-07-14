import BackToTheFuture from 0xf8d6e0586b0a20c7

transaction(name: String) {
    prepare(acct: AuthAccount) {
        acct.save<@BackToTheFuture.State>(<-BackToTheFuture.createState(name: name), to: /storage/state)
    }
}

