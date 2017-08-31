using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MKKA
{
    public enum SettingKeyEnum
    {
        usingKataGroup1,
        usingKataGroup2,
        usingKataGroup3,
        usingKataGroup4,
        usingKataGroup5,
        usingKataGroup6,
        secondsBetweenCallouts,
        leftRightSwitch,
        leftRightFrequency,
        invalidSetting
    }
    public enum SettingTypeEnum
    {
        settingTypeBool,
        settingTypeInt,
        settingTypeFloat,
        settingTypeString,
        settingTypePercentage
    }
    public class Setting
    {
        [PrimaryKey]
        public SettingKeyEnum SettingKey { get; set; }
        public SettingTypeEnum SettingType { get; set; }
        public string SettingValue { get; set; }
    }
}
