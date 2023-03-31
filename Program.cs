using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Jobs;
using BenchmarkDotNet.Running;
using DemoProject.Experiments;

var config = new ManualConfig();
config.AddJob(Job.Dry);
config.AddLogger(DefaultConfig.Instance.GetLoggers().ToArray());
config.AddColumnProvider(DefaultConfig.Instance.GetColumnProviders().ToArray());


BenchmarkRunner.Run<Lists.Append>(config);
BenchmarkRunner.Run<Lists.RemoveLast>(config);
BenchmarkRunner.Run<Lists.InsertFirst>(config);
BenchmarkRunner.Run<Lists.RemoveFirst>(config);

BenchmarkRunner.Run<Sets.Add>(config);
BenchmarkRunner.Run<Sets.Contains>(config);
BenchmarkRunner.Run<Sets.AddWithDifferentHashing>(config);
BenchmarkRunner.Run<Sets.ContainsWithDifferentHashing>(config);


BenchmarkRunner.Run<Sorted.Add>(config);
BenchmarkRunner.Run<Sorted.Contains>(config);
BenchmarkRunner.Run<Sorted.SetVsArray>(config);
