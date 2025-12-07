namespace ______00._020作業2_車輛資訊管理測試
{
	public class UnitTest1
	{
		[Fact]
		public void Constructor_InitialSpeed_IsClampedToMax()
		{
			var car = new _00._020作業2_車輛資訊管理.Car("B", "M", maxSpeed: 200, initialSpeed: 300);
			Assert.Equal(200, car.Speed);
		}

		[Fact]
		public void Accelerate_WithIntMax_DoesNotOverflow_ClampsToMax()
		{
			var car = new _00._020作業2_車輛資訊管理.Car("B", "M", maxSpeed: 400, initialSpeed: 120);
			car.Accelerate(int.MaxValue);
			Assert.Equal(400, car.Speed);
		}

		[Fact]
		public void Brake_LargeAmount_ClampsToZero()
		{
			var car = new _00._020作業2_車輛資訊管理.Car("B", "M", maxSpeed: 400, initialSpeed: 120);
			car.Brake(9999);
			Assert.Equal(0, car.Speed);
		}

		[Theory]
		[InlineData(-1)]
		[InlineData(-100)]
		public void Accelerate_Negative_Throws(int amount)
		{
			var car = new _00._020作業2_車輛資訊管理.Car("B", "M");
			Assert.Throws<ArgumentOutOfRangeException>(() => car.Accelerate(amount));
		}

		[Theory]
		[InlineData(-1)]
		[InlineData(-100)]
		public void Brake_Negative_Throws(int amount)
		{
			var car = new _00._020作業2_車輛資訊管理.Car("B", "M");
			Assert.Throws<ArgumentOutOfRangeException>(() => car.Brake(amount));
		}
	}
}
