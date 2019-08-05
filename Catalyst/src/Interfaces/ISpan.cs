﻿// Copyright (c) Curiosity GmbH - All Rights Reserved. Proprietary and Confidential.
// Unauthorized copying of this file, via any medium is strictly prohibited.

using Mosaik.Core;
using System;
using System.Collections.Generic;

//using MessagePack;

namespace Catalyst
{
    public interface ISpan : IEnumerable<IToken>
    {
        Language Language { get; }
        int Begin { get; set; }
        int End { get; set; }
        int Length { get; }
        int TokensCount { get; }
        string Value { get; }
        ReadOnlySpan<char> ValueAsSpan { get; }
        string TokenizedValue { get; }
        IEnumerable<IToken> Tokens { get; }
        IToken this[int key] { get; set; }

        IToken AddToken(int begin, int end);

        IToken AddToken(IToken token);

        void ReserveTokens(int expectedTokenCount);

        void SetTokenTag(int v, PartOfSpeech tag);

        IEnumerable<ITokens> GetEntities(string filter = "");

        IEnumerable<IToken> GetTokenized();

        Span<Token> ToTokenSpan();
    }
}