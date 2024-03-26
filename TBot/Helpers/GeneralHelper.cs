using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace Tbot.Helpers {
	public static class GeneralHelper {
		public static bool ShouldSleep(DateTime time, DateTime goToSleep, DateTime wakeUp) {
			if (time >= goToSleep) {
				if (time >= wakeUp) {
					if (goToSleep >= wakeUp) {
						return true;
					} else {
						return false;
					}
				} else {
					return true;
				}
			} else {
				if (time >= wakeUp) {
					return false;
				} else {
					if (goToSleep >= wakeUp) {
						return true;
					} else {
						return false;
					}
				}
			}
		}

		public static int ClampSystem(int system) {
			if (system < 1)
				system = 1;
			if (system > 499)
				system = 499;
			return system;
		}

		public static int WrapSystem(int system) {
			if (system > 499)
				system = 1;
			if (system < 1)
				system = 499;
			return system;
		}
		public static T DeepCopy<T>(T item)
        {
            BinaryFormatter formatter = new BinaryFormatter();
            MemoryStream stream = new MemoryStream();
            formatter.Serialize(stream, item);
            stream.Seek(0, SeekOrigin.Begin);
            T result = (T)formatter.Deserialize(stream);
            stream.Close();
            return result;
        }
	}
}
