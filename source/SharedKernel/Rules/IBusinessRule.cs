using System;
using System.Collections.Generic;
using System.Text;

namespace SharedKernel.Rules {
  public interface IBusinessRule {
    bool IsBroken();

    string Message { get; }
  }
}
