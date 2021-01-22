``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.18363.1316 (1909/November2018Update/19H2)
Intel Core i3-3120M CPU 2.50GHz (Ivy Bridge), 1 CPU, 4 logical and 2 physical cores
  [Host]     : .NET Framework 4.8 (4.8.4300.0), X86 LegacyJIT
  DefaultJob : .NET Framework 4.8 (4.8.4300.0), X86 LegacyJIT


```
| Method |     Mean |   Error |  StdDev |
|------- |---------:|--------:|--------:|
|  Test1 | 300.6 ns | 2.93 ns | 2.74 ns |
|  Test2 | 212.4 ns | 3.47 ns | 3.08 ns |
|  Test3 | 112.2 ns | 0.76 ns | 0.71 ns |
|  Test4 | 162.4 ns | 1.55 ns | 1.45 ns |
