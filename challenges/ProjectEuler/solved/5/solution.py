# region From Problem 3


def is_factor(a: int, b: int) -> bool:
    """
    Returns True if b is a factor of a, otherwise returns False.
    """
    return b <= a and a % b == 0


def get_factors(number: int) -> list[int]:
    factors = list[int]()
    i = 1

    while i <= number and i not in factors:
        if is_factor(number, i):
            factors.append(i)
            factors.append(number // i)
        i += 1

    return factors


def is_prime(number: int) -> bool:
    return len(get_factors(number)) == 2


# endregion


def pfd(number: int) -> list[int]:
    """
    Prime factor decomposition.
    """
    if number < 0:
        raise ValueError("Must be a positive integer.")

    if number == 0 or number == 1:
        return []

    factors = get_factors(number)

    if len(factors) == 2:
        return [number]

    factors.remove(1)
    factors.remove(number)

    prime_factors = []

    for x in factors:
        if is_prime(x):
            prime_factors.append(x)
            prime_factors.extend(pfd(number // x))
            break

    return prime_factors


def pfd_to_dict(pfd: list[int]) -> dict[int, int]:
    pfd_list = pfd.copy()
    pfd_dict = {}
    while any(pfd_list):
        n = pfd_list[0]
        count = pfd_list.count(n)
        for _ in range(count):
            pfd_list.remove(n)
        pfd_dict[n] = count
    return pfd_dict


def pfr(pfd: dict[int, int] | list[int]) -> int:
    """
    Prime factor recomposition.
    """
    pfd_dict = pfd_to_dict(pfd) if isinstance(pfd, list) else pfd.copy()
    res = 1
    for n, count in pfd_dict.items():
        res *= pow(n, count)
    return res


def lcm(a: int, b: int) -> int:
    """
    Least common multiple.
    """
    res = 1
    ans = pfd_to_dict(pfd(a))
    for n, count in pfd_to_dict(pfd(b)).items():
        ans[n] = max(ans.get(n, 0), count)

    for n, count in ans.items():
        res *= pow(n, count)

    return res


def lcm_many(numbers: list[int]) -> int:
    """
    Least common multiple.
    """
    n_set = set(numbers)
    a = n_set.pop()
    while any(n_set):
        b = n_set.pop()
        a = lcm(a, b)
    return a


# def take_integer():
#     num = input("Enter a whole number: ")
#     return int(num)


# def main():
#     flag = True
#     while flag:
#         a = take_integer()
#         b = take_integer()
#         print(f"lcm({a}, {b}) = {lcm(a, b)}")
#         _ = input("Press anything to perform another LCM calculation.")


# main()


# _pfd = pfd(27_000)
# print(_pfd)
# print(pfd_to_dict(_pfd))
# print(pfr(_pfd))

print(lcm_many([x for x in range(1, 21)]))
