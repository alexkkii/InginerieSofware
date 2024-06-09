using InsuranceBroker;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsuranceBrokerTest
{
    public class InsurancePolicyTests
    {
        [Fact]
        public void InsurancePolicy_ShouldAssignVehicle()
        {
            // Arrange
            var vehicle = new Vehicle { ID = "V100", Make = "Honda", Model = "Civic" };
            var policy = new InsurancePolicy();

            // Act
            policy.InsuredEntity = vehicle;

            // Assert
            Assert.Equal(vehicle, policy.InsuredEntity);
            Assert.IsType<Vehicle>(policy.InsuredEntity);
        }

        [Fact]
        public void InsurancePolicy_ShouldAssignPerson()
        {
            // Arrange
            var person = new Person { ID = "P100", FirstName = "John", LastName = "Doe" };
            var policy = new InsurancePolicy();

            // Act
            policy.InsuredEntity = person;

            // Assert
            Assert.Equal(person, policy.InsuredEntity);
            Assert.IsType<Person>(policy.InsuredEntity);
        }

        [Fact]
        public void ModifyPolicyDuration_ByValue_ShouldNotChangeOriginalValue()
        {
            // Arrange
            var policy = new InsurancePolicy { DurationMonths = 12 };

            // Act
            ModifyDuration(policy.DurationMonths, 24);

            // Assert
            Assert.Equal(12, policy.DurationMonths); // Original should remain unchanged
        }

        [Fact]
        public void ModifyPolicyDuration_ByReference_ShouldChangeOriginalValue()
        {
            // Arrange
            var policy = new InsurancePolicy { DurationMonths = 12 };
            int tempDuration = policy.DurationMonths; // Use a temporary variable

            // Act
            ModifyDuration(ref tempDuration, 24);

            // Assign the modified value back to the property
            policy.DurationMonths = tempDuration;

            // Assert
            Assert.Equal(24, policy.DurationMonths); // Original should be changed
        }

        private void ModifyDuration(int duration, int newDuration)
        {
            // This method simulates modifying the value by value
            duration = newDuration;
        }

        private void ModifyDuration(ref int duration, int newDuration)
        {
            // This method simulates modifying the value by reference
            duration = newDuration;
        }
    }

}
