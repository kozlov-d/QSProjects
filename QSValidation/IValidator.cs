﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace QSValidation
{
	public interface IValidator
	{
		bool ShowResultsIfNotValid { get; set; }
		bool Validate();
		bool Validate(ValidationContext validationContext);
		IEnumerable<ValidationResult> Results { get; }
	}
}