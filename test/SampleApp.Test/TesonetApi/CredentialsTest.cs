﻿using System.IO;
using FluentAssertions;
using Newtonsoft.Json;
using SampleApp.TesonetApi;
using Xunit;

namespace SampleApp.Test.TesonetApi
{
    public class CredentialsTest
    {
        [Fact]
        public void EmptyCredentialsNotValid()
        {
            var sut = new Credentials(" ", "");
            sut.IsValid(out string error).Should().BeFalse();
            error.Should().Be("Invalid credentials");
        }

        [Fact]
        public void ConvertsToJson()
        {
            var sut = new Credentials("testUser", "testPassword");
            sut.ToJObject().ToString(Formatting.None).Should().Be("{\"username\":\"testUser\",\"password\":\"testPassword\"}");
        }
    }
}
