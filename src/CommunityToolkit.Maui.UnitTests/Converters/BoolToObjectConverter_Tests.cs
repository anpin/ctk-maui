﻿using System.Globalization;
using CommunityToolkit.Maui.Converters;
using Xunit;

namespace CommunityToolkit.Maui.UnitTests.Converters;

public class BoolToObjectConverter_Tests : BaseTest
{
	public const string TrueTestObject = nameof(TrueTestObject);
	public const string FalseTestObject = nameof(FalseTestObject);

	[Theory]
	[InlineData(true, TrueTestObject, FalseTestObject, TrueTestObject)]
	[InlineData(false, TrueTestObject, FalseTestObject, FalseTestObject)]
	public void BoolToObjectConvert(bool value, object trueObject, object falseObject, object expectedResult)
	{
		var boolObjectConverter = new BoolToObjectConverter
		{
			TrueObject = trueObject,
			FalseObject = falseObject
		};

		var convertResult = ((ICommunityToolkitValueConverter)boolObjectConverter).Convert(value, typeof(object), null, CultureInfo.CurrentCulture);
		var convertFromResult = boolObjectConverter.ConvertFrom(value);

		Assert.NotNull(convertResult);
		Assert.NotNull(convertFromResult);

		Assert.Equal(expectedResult, convertResult);
		Assert.Equal(expectedResult, convertFromResult);
	}

	[Theory]
	[InlineData(true, TrueTestObject, FalseTestObject, TrueTestObject)]
	[InlineData(false, TrueTestObject, FalseTestObject, FalseTestObject)]
	public void BoolToObjectTConvert(bool value, string trueObject, string falseObject, object expectedResult)
	{
		var boolObjectConverter = new BoolToObjectConverter<string>
		{
			TrueObject = trueObject,
			FalseObject = falseObject
		};

		var convertResult = ((ICommunityToolkitValueConverter)boolObjectConverter).Convert(value, typeof(string), null, CultureInfo.CurrentCulture);
		var convertFromResult = boolObjectConverter.ConvertFrom(value);

		Assert.NotNull(convertResult);
		Assert.NotNull(convertFromResult);

		Assert.Equal(expectedResult, convertResult);
		Assert.Equal(expectedResult, convertFromResult);
	}

	[Theory]
	[InlineData(TrueTestObject, TrueTestObject, FalseTestObject, true)]
	[InlineData(FalseTestObject, TrueTestObject, FalseTestObject, false)]
	public void BoolToObjectConvertBack(object value, object trueObject, object falseObject, bool expectedResult)
	{
		var boolObjectConverter = new BoolToObjectConverter
		{
			TrueObject = trueObject,
			FalseObject = falseObject
		};

		var convertBackResult = (bool?)((ICommunityToolkitValueConverter)boolObjectConverter).ConvertBack(value, typeof(bool), null, CultureInfo.CurrentCulture);
		var convertBackToResult = boolObjectConverter.ConvertBackTo(value);

		Assert.Equal(expectedResult, convertBackResult);
		Assert.Equal(expectedResult, convertBackToResult);
	}

	[Theory]
	[InlineData(TrueTestObject, TrueTestObject, FalseTestObject, true)]
	[InlineData(FalseTestObject, TrueTestObject, FalseTestObject, false)]
	public void BoolToObjectTConvertBack(string value, string trueObject, string falseObject, bool expectedResult)
	{
		var boolObjectConverter = new BoolToObjectConverter<string>
		{
			TrueObject = trueObject,
			FalseObject = falseObject
		};

		var convertBackResult = (bool?)((ICommunityToolkitValueConverter)boolObjectConverter).ConvertBack(value, typeof(bool), null, CultureInfo.CurrentCulture);
		var convertBackToResult = boolObjectConverter.ConvertBackTo(value);

		Assert.Equal(expectedResult, convertBackResult);
		Assert.Equal(expectedResult, convertBackToResult);
	}

	[Theory]
	[InlineData(0)]
	[InlineData(5.5)]
	[InlineData('c')]
	[InlineData("abc")]
	public void BoolToObjectInvalidValuesThrowArgumentException(object value)
	{
		var boolObjectConverter = new BoolToObjectConverter();
		Assert.Throws<ArgumentException>(() => ((ICommunityToolkitValueConverter)boolObjectConverter).Convert(value, typeof(object), null, CultureInfo.CurrentCulture));
	}

	[Theory]
	[InlineData(0)]
	[InlineData(5.5)]
	[InlineData('c')]
	[InlineData("abc")]
	public void BoolToObjectTInvalidValuesThrowArgumentException(object value)
	{
		var boolObjectConverter = new BoolToObjectConverter<DateTime>();
		Assert.Throws<ArgumentException>(() => ((ICommunityToolkitValueConverter)boolObjectConverter).ConvertBack(value, typeof(object), null, CultureInfo.CurrentCulture));
	}

	[Fact]
	public void BoolToObjectConverterNullInputTest()
	{
#pragma warning disable CS8625 // Cannot convert null literal to non-nullable reference type.
		Assert.Throws<ArgumentNullException>(() => ((ICommunityToolkitValueConverter)new BoolToObjectConverter()).Convert(null, typeof(object), null, null));
		Assert.Throws<ArgumentNullException>(() => ((ICommunityToolkitValueConverter)new BoolToObjectConverter()).Convert(true, null, null, null));
		Assert.Throws<ArgumentNullException>(() => ((ICommunityToolkitValueConverter)new BoolToObjectConverter()).ConvertBack(true, null, null, null));
#pragma warning restore CS8625 // Cannot convert null literal to non-nullable reference type.
	}

	[Fact]
	public void BoolToObjectTConverterNullInputTest()
	{
#pragma warning disable CS8625 // Cannot convert null literal to non-nullable reference type.
		Assert.Throws<ArgumentException>(() => ((ICommunityToolkitValueConverter)new BoolToObjectConverter<string>()).Convert(null, typeof(object), null, null));
		Assert.Throws<ArgumentNullException>(() => ((ICommunityToolkitValueConverter)new BoolToObjectConverter<string>()).Convert(true, null, null, null));
		Assert.Throws<ArgumentNullException>(() => ((ICommunityToolkitValueConverter)new BoolToObjectConverter<string>()).ConvertBack(true, null, null, null));
#pragma warning restore CS8625 // Cannot convert null literal to non-nullable reference type.
	}
}