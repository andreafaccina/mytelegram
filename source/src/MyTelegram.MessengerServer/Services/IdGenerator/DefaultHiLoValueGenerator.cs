﻿namespace MyTelegram.MessengerServer.Services.IdGenerator;

public class DefaultHiLoValueGenerator : HiLoValueGenerator<long>
{
    private readonly int _blockSize;
    private readonly IHiLoHighValueGenerator _highValueGenerator;
    private readonly ILogger<DefaultHiLoValueGenerator> _logger;

    public DefaultHiLoValueGenerator(HiLoValueGeneratorState generatorState,
        ILogger<DefaultHiLoValueGenerator> logger,
        IHiLoHighValueGenerator highValueGenerator) : base(generatorState)
    {
        _logger = logger;
        _highValueGenerator = highValueGenerator;
        _blockSize = generatorState.BlockSize;
    }

    protected override long GetNewLowValue(IdType idType,
        long key)
    {
        throw new NotImplementedException();
    }

    protected override async Task<long> GetNewLowValueAsync(IdType idType,
        long key,
        CancellationToken cancellationToken = default)
    {
        var highValue = await _highValueGenerator.GetNewHighValueAsync(idType, key, cancellationToken)
            ;
        _logger.LogInformation("Get new low value from db,idType={IdType} key={Key} newHighValue={HighValue}",
            idType,
            key,
            highValue);

        return (highValue - 1) * _blockSize + 1;
    }
}