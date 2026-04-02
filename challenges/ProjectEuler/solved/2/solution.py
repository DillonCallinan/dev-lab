from typing import Iterator


class Fibonacci(Iterator[int]):
    _terms: list[int]
    _iter: int
    _max: int

    def __init__(self, first_term: int, second_term: int, max: int) -> None:
        self._terms = [first_term, second_term]
        self._iter = 0
        self._max = max

    def __next__(self) -> int:
        return self._next()

    def _extend(self) -> None:
        next = self._terms[-1] + self._terms[-2]
        if next >= self._max:
            self._iter = -1
        else:
            self._terms.append(next)

    def _next(self) -> int:
        if self._iter < 0:
            raise StopIteration

        if self._iter < len(self._terms):
            next = self._terms[self._iter]
            self._iter += 1
            return next

        self._extend()
        return self._next()


def is_even(number: int) -> bool:
    return number % 2 == 0


ans = sum(x for x in Fibonacci(1, 2, 4_000_000) if is_even(x))

print(ans)
