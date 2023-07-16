import BackToTheFuture from 0xf8d6e0586b0a20c7

transaction {
    prepare(acct: AuthAccount) {

        acct.save(<-BackToTheFuture.createState(name:"allen"), to: /storage/State)

        acct.link<&BackToTheFuture.State>(/public/Statepub, target: /storage/State)

    }
}