from typing import Iterator


# Not used in this solution
class Primes(Iterator[int]):
    _primes: set[int]
    _i: int
    _max: int

    def __init__(self, max: int = 10_000) -> None:
        self._primes = set()
        self._i = 0
        self._max = max

    def __next__(self) -> int:
        return self._next()

    def _next(self) -> int:
        self._i += 1
        if self._i > self._max:
            raise StopIteration

        if is_prime(self._i):
            self._primes.add(self._i)
            return self._i

        return self._next()


def is_factor(a: int, b: int) -> bool:
    """
    Returns True if b is a factor of a, otherwise returns False.
    """
    return b <= a and a % b == 0


def get_factors(number: int) -> set[int]:
    factors = set[int]()
    i = 1

    while i <= number and i not in factors:
        if is_factor(number, i):
            factors.add(i)
            factors.add(number // i)
        i += 1

    return factors


def is_prime(number: int) -> bool:
    return len(get_factors(number)) == 2


def get_prime_factors(number: int) -> set[int]:
    return set(x for x in get_factors(number) if is_prime(x))


ans = max(get_prime_factors(600851475143))

print(ans)
