﻿namespace Core.Business.Results;

public interface IDataResult<out T> : IResult
{
    T Data { get; }
}
