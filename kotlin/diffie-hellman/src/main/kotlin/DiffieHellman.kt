import java.math.BigInteger
import kotlin.random.Random

object DiffieHellman {

    private val TWO = BigInteger.valueOf(2)

    fun privateKey(prime: BigInteger): BigInteger {
        require(prime > TWO)

        while (true) {
            val candidate = Random.nextLong(2, prime.toLong()).toBigInteger()

            if (candidate >= TWO && candidate < prime) {
                return candidate
            }
        }
    }

    fun publicKey(p: BigInteger, g: BigInteger, privKey: BigInteger): BigInteger {
        return g.modPow(privKey, p)
    }

    fun secret(prime: BigInteger, publicKey: BigInteger, privateKey: BigInteger): BigInteger {
        return publicKey.modPow(privateKey, prime)
    }
}
