class BankAccount {

    private var closed = false
    private var _balance = 0L

    val balance: Long
        @Synchronized get() {
            check(!closed)
            return _balance
        }

    @Synchronized
    fun adjustBalance(amount: Long) {
        check(!closed)
        _balance += amount
    }

    @Synchronized
    fun close() {
        closed = true
    }
}
