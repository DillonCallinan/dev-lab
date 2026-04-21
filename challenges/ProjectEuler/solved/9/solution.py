sum = 1000
res = ()

for c in range(sum, 0, -1):
    for a in range(1, -(-(sum + 1 - c) // 2)):
        b = sum - c - a
        if pow(a, 2) + pow(b, 2) == pow(c, 2):
            res = (a, b, c)
            break

assert res
a, b, c = res
print(f"{a=}, {b=}, {c=}")
print(a * b * c)
