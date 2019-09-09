using Moq;

using Pekka.Core.Builders;
using Pekka.Core.Contracts;

using System;
using System.Collections.Generic;

using Pekka.Core.Attributes;

using Xunit;

namespace Pekka.Core.Tests
{
    public class PropertyQueryStringBuilderTests
    {
        [Fact]
        public void ProcessRequest_Should_Throw_ArgumentNullException_If_Filter_Is_Null()
        {
            var builder = new PropertyQueryStringBuilder();

            Assert.Throws<ArgumentNullException>(() =>
                builder.ProcessRequest<FilterWithoutQueryAttribute>(new List<KeyValuePair<string, string>>(), null));
        }

        [Fact]
        public void
            ProcessRequest_Should_Pass_Same_QueryStringParams_And_Filter_To_Successor_If_Filter_Do_Not_Have_Property_With_QueryAttribute_And_Successor_Is_Not_Null()
        {
            var queryStringBuilder = new Mock<QueryStringBuilder>(MockBehavior.Strict);
            var propertyQueryStringBuilder = new PropertyQueryStringBuilder();
            propertyQueryStringBuilder.SetSuccessor(queryStringBuilder.Object);

            var filterWithoutQueryAttribute = new FilterWithoutQueryAttribute();
            var queryParameters = new List<KeyValuePair<string, string>>();

            queryStringBuilder.Setup(builder =>
                builder.ProcessRequest(
                    It.Is<IList<KeyValuePair<string, string>>>(stringBuilder => Equals(queryParameters, stringBuilder)),
                    It.Is<FilterWithoutQueryAttribute>(dummyFilter => dummyFilter == filterWithoutQueryAttribute)));

            propertyQueryStringBuilder.ProcessRequest(queryParameters, filterWithoutQueryAttribute);

            queryStringBuilder.Verify(
                builder => builder.ProcessRequest(It.IsAny<IList<KeyValuePair<string, string>>>(),
                    It.IsAny<FilterWithoutQueryAttribute>()), Times.Once);
        }

        [Fact]
        public void ProcessRequest_Should_Initialize_QueryStringParams_If_It_Null()
        {
            var queryStringBuilder = new Mock<QueryStringBuilder>(MockBehavior.Strict);
            var propertyQueryStringBuilder = new PropertyQueryStringBuilder();
            propertyQueryStringBuilder.SetSuccessor(queryStringBuilder.Object);

            queryStringBuilder.Setup(builder =>
                builder.ProcessRequest(It.IsAny<IList<KeyValuePair<string, string>>>(),
                    It.IsAny<PairPropertyFilter>()));

            propertyQueryStringBuilder.ProcessRequest(null, new PairPropertyFilter());

            queryStringBuilder.Verify(
                builder => builder.ProcessRequest(
                    It.Is<IList<KeyValuePair<string, string>>>(stringBuilder => stringBuilder != null),
                    It.IsAny<PairPropertyFilter>()), Times.Once);
        }

        [Fact]
        public void
            ProcessRequest_Should_Not_Add_Property_Value_As_Query_String_Parameter_If_Value_Of_The_Property_Is_Null()
        {
            var propertyQueryStringBuilder = new PropertyQueryStringBuilder();

            var clanFilter = new PairPropertyFilter {Name = "Eyyam"};
            var queryParameters = new List<KeyValuePair<string, string>>();

            propertyQueryStringBuilder.ProcessRequest(queryParameters, clanFilter);

            Assert.Single(queryParameters);
            Assert.Contains(new KeyValuePair<string, string>("name", clanFilter.Name), queryParameters);
        }

        [Fact]
        public void ProcessRequest_Should_Add_All_Propert_Values_As_Query_String_Parameter_If_Values_Are_Not_Null()
        {
            var propertyQueryStringBuilder = new PropertyQueryStringBuilder();

            var clanFilter = new PairPropertyFilter {Name = "Eyyam", Tag = "ATSGEDS"};
            var queryParameters = new List<KeyValuePair<string, string>>();

            propertyQueryStringBuilder.ProcessRequest(queryParameters, clanFilter);

            Assert.Equal(2, queryParameters.Count);
            Assert.Contains(new KeyValuePair<string, string>("name", clanFilter.Name), queryParameters);
            Assert.Contains(new KeyValuePair<string, string>("tag", clanFilter.Tag), queryParameters);
        }

        [Fact]
        public void ProcessRequest_Should_Pass_Same_QueryStringParams_And_Filter_To_Successor()
        {
            var queryStringBuilder = new Mock<QueryStringBuilder>(MockBehavior.Strict);
            var propertyQueryStringBuilder = new PropertyQueryStringBuilder();
            propertyQueryStringBuilder.SetSuccessor(queryStringBuilder.Object);

            queryStringBuilder.Setup(builder =>
                builder.ProcessRequest(It.IsAny<IList<KeyValuePair<string, string>>>(),
                    It.IsAny<PairPropertyFilter>()));

            var clanFilter = new PairPropertyFilter {Name = "Eyyam", Tag = "ATSGEDS"};
            var queryParameters = new List<KeyValuePair<string, string>>();

            propertyQueryStringBuilder.ProcessRequest(queryParameters, clanFilter);

            queryStringBuilder.Verify(
                builder => builder.ProcessRequest(
                    It.Is<IList<KeyValuePair<string, string>>>(stringBuilder => Equals(stringBuilder, queryParameters)),
                    It.Is<PairPropertyFilter>(filter => Equals(filter, clanFilter))), Times.Once);
        }
    }

    public class FilterWithoutQueryAttribute : IFilter
    {
        public string Name { get; set; }

        public string Tag { get; set; }
    }

    public class PairPropertyFilter : IFilter
    {
        [Query("name")] public string Name { get; set; }

        [Query("tag")] public string Tag { get; set; }
    }
}