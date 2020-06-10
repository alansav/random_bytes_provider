# Random Bytes Provider

[![Build status](https://ci.appveyor.com/api/projects/status/ps6desgvlydyn2v0?svg=true)](https://ci.appveyor.com/project/alansav/random-bytes-provider)

Generate cryptographically secure bytes using a provider that can be easily mocked in unit tests.

## Usage

Add the nuget package RandomBytesProvider to your project

```c#
using Savage.Providers;
using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            var provider = new RandomBytesProvider();
            var random = provider.GetBytes(8);
            Console.WriteLine(BitConverter.ToString(random));
        }
    }
}
```

Example output: C9-75-89-FD-33-D4-A0-05

The above code is great but may present a challenge when writing some unit tests because of the nature of random bytes - they are different each time it is called.

```c#
using Savage.Providers;
using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            var example = new Example(provider);
            example.DisplayRandomData();
        }

        public class Example
        {
            private readonly IRandomBytesProvider _provider;

            public Example(IRandomBytesProvider provider)
            {
                _provider = provider;
            }

            public void DisplayRandomData()
            {
                var random = _provider.GetBytes(8);
                Console.WriteLine(BitConverter.ToString(random));
            }
        }
    }
}

```

This would enable us to write a unit test for the Example class and mock out the IRandomBytesProvider enabling us to provide a known value for GetBytes.
