import BackToTheFuture from 0x02

transaction {
    prepare(acct: AuthAccount) {

        acct.save<-BackToTheFuture.createState, to: /storage/state)            //?? panic("Could not load counter resource")

    }
}
