﻿
using System;

namespace FitnOne.BL.Model
{
    /// <summary>
    /// User.
    /// </summary>
    [Serializable]
    public class User
    {
        #region Properties
        /// <summary>
        /// Name.
        /// </summary>
        public string Name { get; }
        /// <summary>
        /// Gender.
        /// </summary>
        public Gender Gender { get; set; }//Need fix
        /// <summary>
        /// Day of birth.
        /// </summary>
        public DateTime BirthDate { get; set; }//Need fix
        /// <summary>
        /// Weight.
        /// </summary>
        public double Weight { get; set; }
        /// <summary>
        /// Height.
        /// </summary>
        public double Height { get; set; }

        /* 
         * DateTime nowDate = DateTime.Today;
         * int age = nowDate.Year - birthDate.Year;
         * if(birthDate > nowDate.AddYears(-age)) age--;
         */
        public int Age { get { return DateTime.Now.Year - BirthDate.Year; } }
        #endregion
        /// <summary>
        /// Create new user.
        /// </summary>
        /// <param name="name">Name.</param>
        /// <param name="gender">Gender.</param>
        /// <param name="birthDate">Day of birth.</param>
        /// <param name="weight">Weight.</param>
        /// <param name="height">Height.</param>

        public User(string name, Gender gender, DateTime birthDate, double weight, double height)
        {
            #region Parameter sheck
            if (string.IsNullOrWhiteSpace(name)) 
            { 
                throw new ArgumentNullException("Name cannot be null or empty", nameof(name)); 
            }
            if(gender == null) 
            {
                throw new ArgumentNullException("Gender cannot be null or empty", nameof(gender));
            } 
            if( (birthDate < DateTime.Parse("01.01.1900"))||(birthDate > DateTime.Now) )
            {
                throw new ArgumentException("Invalid date input", nameof(birthDate));
            } 
            if(weight <= 0) 
            { 
                throw new ArgumentException("Weight must be equal or greater than zero", nameof(weight)); 
            }
            if(height <= 0) 
            {
                throw new ArgumentException("Height must be equal or greater than zero", nameof(height));
            }
            #endregion
           
            Name = name;
            Gender = gender;
            BirthDate = birthDate;
            Weight = weight;
            Height = height;
        }
        public User(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException("Name cannot be null or empty", nameof(name));
            }
            Name = name;
        }
        public override string ToString()
        {
            return Name + " " + Age;
        }
    }
}
