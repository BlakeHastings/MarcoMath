```

BenchmarkDotNet v0.13.10, Windows 11 (10.0.22621.2428/22H2/2022Update/SunValley2)
Intel Core i9-9900K CPU 3.60GHz (Coffee Lake), 1 CPU, 16 logical and 8 physical cores
.NET SDK 7.0.203
  [Host]     : .NET 6.0.16 (6.0.1623.17311), X64 RyuJIT AVX2
  DefaultJob : .NET 6.0.16 (6.0.1623.17311), X64 RyuJIT AVX2


```
| Method         | Mean     | Error    | StdDev   | Rank | Gen0   | Allocated |
|--------------- |---------:|---------:|---------:|-----:|-------:|----------:|
| MarcoBenchmark | 12.31 μs | 0.075 μs | 0.063 μs |    1 | 1.3123 |  10.82 KB |
