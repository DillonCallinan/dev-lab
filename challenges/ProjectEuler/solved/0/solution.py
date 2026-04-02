
import time

start_time = time.perf_counter()

odd_nums = range(1, 317000, 2)

ans = sum(x * x for x in odd_nums)

end_time = time.perf_counter()

elapsed_time = end_time - start_time

print(ans)
print(elapsed_time, "s")
