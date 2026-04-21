import time
from typing import Iterator


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

        if self._is_prime(self._i):
            self._primes.add(self._i)
            return self._i

        return self._next()

    def _is_prime(self, number: int) -> bool:
        if number <= 1:
            return False
        if number >= 10:
            d = get_digits(number)[-1]
            if d in [0, 2, 4, 5, 6, 8]:
                return False

        lower = 1
        upper = number
        primes = [*self._primes]
        primes.sort()

        for p in primes:
            lower = p
            if lower > upper:
                break
            if number % lower == 0:
                return False
            upper = number / lower

        return True


# region From Problem 3


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


# endregion


# region From Problem 4


def get_digits(number: int) -> list[int]:
    number = abs(number)

    if number == 0:
        return [0]

    digits = []
    i = 1

    while i <= number:
        j = 10 * i
        digit = (i * (number // i) - j * (number // (j))) // i
        digits.append(digit)
        i = j

    digits.reverse()
    return digits


# endregion


def main():
    start = time.perf_counter()
    t = start
    for i, p in enumerate(Primes(1_000_000)):
        if i % 500 == 0:
            t_2 = time.perf_counter()
            print(
                f"{i=}, at {t_2 - start}s (avg {(t_2 - t) / 500}s per prime for last 500 primes calculated)"
            )
            t = t_2
        if i == 10_000:
            print(f"{p=}, took {time.perf_counter() - start}s")
            break


main()


# Attempt 1:
# p=104743, took 97.57025899994187s

# Attempt 2:
# Replaced call to is_prime() in Primes._next()
# with a more performative version, Primes._is_prime().
# p=104743, took 11.683127199998125s
