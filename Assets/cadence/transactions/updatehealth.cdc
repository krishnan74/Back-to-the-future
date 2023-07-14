import BackToTheFuture from 0x02

transaction {
    prepare(acct: AuthAccount) {
        let ref <- acct.load<@BackToTheFuture.State>(from: /storage/state)            //?? panic("Could not load counter resource")

        ref?.updateHealth(_value: 5)

        acct.save(<-ref!, to: /storage/state)
    }
}