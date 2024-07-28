; ModuleID = 'obj\Debug\130\android\marshal_methods.armeabi-v7a.ll'
source_filename = "obj\Debug\130\android\marshal_methods.armeabi-v7a.ll"
target datalayout = "e-m:e-p:32:32-Fi8-i64:64-v128:64:128-a:0:32-n32-S64"
target triple = "armv7-unknown-linux-android"


%struct.MonoImage = type opaque

%struct.MonoClass = type opaque

%struct.MarshalMethodsManagedClass = type {
	i32,; uint32_t token
	%struct.MonoClass*; MonoClass* klass
}

%struct.MarshalMethodName = type {
	i64,; uint64_t id
	i8*; char* name
}

%class._JNIEnv = type opaque

%class._jobject = type {
	i8; uint8_t b
}

%class._jclass = type {
	i8; uint8_t b
}

%class._jstring = type {
	i8; uint8_t b
}

%class._jthrowable = type {
	i8; uint8_t b
}

%class._jarray = type {
	i8; uint8_t b
}

%class._jobjectArray = type {
	i8; uint8_t b
}

%class._jbooleanArray = type {
	i8; uint8_t b
}

%class._jbyteArray = type {
	i8; uint8_t b
}

%class._jcharArray = type {
	i8; uint8_t b
}

%class._jshortArray = type {
	i8; uint8_t b
}

%class._jintArray = type {
	i8; uint8_t b
}

%class._jlongArray = type {
	i8; uint8_t b
}

%class._jfloatArray = type {
	i8; uint8_t b
}

%class._jdoubleArray = type {
	i8; uint8_t b
}

; assembly_image_cache
@assembly_image_cache = local_unnamed_addr global [0 x %struct.MonoImage*] zeroinitializer, align 4
; Each entry maps hash of an assembly name to an index into the `assembly_image_cache` array
@assembly_image_cache_hashes = local_unnamed_addr constant [246 x i32] [
	i32 32687329, ; 0: Xamarin.AndroidX.Lifecycle.Runtime => 0x1f2c4e1 => 64
	i32 34715100, ; 1: Xamarin.Google.Guava.ListenableFuture.dll => 0x211b5dc => 96
	i32 39109920, ; 2: Newtonsoft.Json.dll => 0x254c520 => 14
	i32 57263871, ; 3: Xamarin.Forms.Core.dll => 0x369c6ff => 91
	i32 101534019, ; 4: Xamarin.AndroidX.SlidingPaneLayout => 0x60d4943 => 80
	i32 120558881, ; 5: Xamarin.AndroidX.SlidingPaneLayout.dll => 0x72f9521 => 80
	i32 134690465, ; 6: Xamarin.Kotlin.StdLib.Jdk7.dll => 0x80736a1 => 100
	i32 165246403, ; 7: Xamarin.AndroidX.Collection.dll => 0x9d975c3 => 41
	i32 182336117, ; 8: Xamarin.AndroidX.SwipeRefreshLayout.dll => 0xade3a75 => 82
	i32 209399409, ; 9: Xamarin.AndroidX.Browser.dll => 0xc7b2e71 => 39
	i32 220171995, ; 10: System.Diagnostics.Debug => 0xd1f8edb => 114
	i32 230216969, ; 11: Xamarin.AndroidX.Legacy.Support.Core.Utils.dll => 0xdb8d509 => 58
	i32 230752869, ; 12: Microsoft.CSharp.dll => 0xdc10265 => 11
	i32 232815796, ; 13: System.Web.Services => 0xde07cb4 => 113
	i32 261689757, ; 14: Xamarin.AndroidX.ConstraintLayout.dll => 0xf99119d => 44
	i32 278686392, ; 15: Xamarin.AndroidX.Lifecycle.LiveData.dll => 0x109c6ab8 => 62
	i32 280482487, ; 16: Xamarin.AndroidX.Interpolator => 0x10b7d2b7 => 56
	i32 318968648, ; 17: Xamarin.AndroidX.Activity.dll => 0x13031348 => 31
	i32 321597661, ; 18: System.Numerics => 0x132b30dd => 24
	i32 342366114, ; 19: Xamarin.AndroidX.Lifecycle.Common => 0x146817a2 => 60
	i32 347068432, ; 20: SQLitePCLRaw.lib.e_sqlite3.android.dll => 0x14afd810 => 18
	i32 385762202, ; 21: System.Memory.dll => 0x16fe439a => 23
	i32 393699800, ; 22: Firebase => 0x177761d8 => 7
	i32 441335492, ; 23: Xamarin.AndroidX.ConstraintLayout.Core => 0x1a4e3ec4 => 43
	i32 442521989, ; 24: Xamarin.Essentials => 0x1a605985 => 90
	i32 442565967, ; 25: System.Collections => 0x1a61054f => 118
	i32 450948140, ; 26: Xamarin.AndroidX.Fragment.dll => 0x1ae0ec2c => 55
	i32 459347974, ; 27: System.Runtime.Serialization.Primitives.dll => 0x1b611806 => 117
	i32 465846621, ; 28: mscorlib => 0x1bc4415d => 13
	i32 469710990, ; 29: System.dll => 0x1bff388e => 22
	i32 476646585, ; 30: Xamarin.AndroidX.Interpolator.dll => 0x1c690cb9 => 56
	i32 486930444, ; 31: Xamarin.AndroidX.LocalBroadcastManager.dll => 0x1d05f80c => 68
	i32 526420162, ; 32: System.Transactions.dll => 0x1f6088c2 => 107
	i32 527452488, ; 33: Xamarin.Kotlin.StdLib.Jdk7 => 0x1f704948 => 100
	i32 605376203, ; 34: System.IO.Compression.FileSystem => 0x24154ecb => 111
	i32 610194910, ; 35: System.Reactive.dll => 0x245ed5de => 26
	i32 627609679, ; 36: Xamarin.AndroidX.CustomView => 0x2568904f => 49
	i32 639843206, ; 37: Xamarin.AndroidX.Emoji2.ViewsHelper.dll => 0x26233b86 => 54
	i32 663517072, ; 38: Xamarin.AndroidX.VersionedParcelable => 0x278c7790 => 87
	i32 666292255, ; 39: Xamarin.AndroidX.Arch.Core.Common.dll => 0x27b6d01f => 36
	i32 690569205, ; 40: System.Xml.Linq.dll => 0x29293ff5 => 30
	i32 691348768, ; 41: Xamarin.KotlinX.Coroutines.Android.dll => 0x29352520 => 102
	i32 700284507, ; 42: Xamarin.Jetbrains.Annotations => 0x29bd7e5b => 97
	i32 720511267, ; 43: Xamarin.Kotlin.StdLib.Jdk8 => 0x2af22123 => 101
	i32 748832960, ; 44: SQLitePCLRaw.batteries_v2 => 0x2ca248c0 => 16
	i32 775507847, ; 45: System.IO.Compression => 0x2e394f87 => 110
	i32 809851609, ; 46: System.Drawing.Common.dll => 0x30455ad9 => 109
	i32 843511501, ; 47: Xamarin.AndroidX.Print => 0x3246f6cd => 75
	i32 928116545, ; 48: Xamarin.Google.Guava.ListenableFuture => 0x3751ef41 => 96
	i32 955402788, ; 49: Newtonsoft.Json => 0x38f24a24 => 14
	i32 956575887, ; 50: Xamarin.Kotlin.StdLib.Jdk8.dll => 0x3904308f => 101
	i32 967690846, ; 51: Xamarin.AndroidX.Lifecycle.Common.dll => 0x39adca5e => 60
	i32 974778368, ; 52: FormsViewGroup.dll => 0x3a19f000 => 8
	i32 992768348, ; 53: System.Collections.dll => 0x3b2c715c => 118
	i32 1012816738, ; 54: Xamarin.AndroidX.SavedState.dll => 0x3c5e5b62 => 79
	i32 1015809712, ; 55: Base2 => 0x3c8c06b0 => 5
	i32 1035644815, ; 56: Xamarin.AndroidX.AppCompat => 0x3dbaaf8f => 35
	i32 1042160112, ; 57: Xamarin.Forms.Platform.dll => 0x3e1e19f0 => 93
	i32 1052210849, ; 58: Xamarin.AndroidX.Lifecycle.ViewModel.dll => 0x3eb776a1 => 65
	i32 1084122840, ; 59: Xamarin.Kotlin.StdLib => 0x409e66d8 => 99
	i32 1098259244, ; 60: System => 0x41761b2c => 22
	i32 1175144683, ; 61: Xamarin.AndroidX.VectorDrawable.Animated => 0x460b48eb => 85
	i32 1178241025, ; 62: Xamarin.AndroidX.Navigation.Runtime.dll => 0x463a8801 => 72
	i32 1204270330, ; 63: Xamarin.AndroidX.Arch.Core.Common => 0x47c7b4fa => 36
	i32 1264511973, ; 64: Xamarin.AndroidX.Startup.StartupRuntime.dll => 0x4b5eebe5 => 81
	i32 1267360935, ; 65: Xamarin.AndroidX.VectorDrawable => 0x4b8a64a7 => 86
	i32 1275534314, ; 66: Xamarin.KotlinX.Coroutines.Android => 0x4c071bea => 102
	i32 1292207520, ; 67: SQLitePCLRaw.core.dll => 0x4d0585a0 => 17
	i32 1293217323, ; 68: Xamarin.AndroidX.DrawerLayout.dll => 0x4d14ee2b => 51
	i32 1324164729, ; 69: System.Linq => 0x4eed2679 => 119
	i32 1365406463, ; 70: System.ServiceModel.Internals.dll => 0x516272ff => 104
	i32 1376866003, ; 71: Xamarin.AndroidX.SavedState => 0x52114ed3 => 79
	i32 1395857551, ; 72: Xamarin.AndroidX.Media.dll => 0x5333188f => 69
	i32 1406073936, ; 73: Xamarin.AndroidX.CoordinatorLayout => 0x53cefc50 => 45
	i32 1411638395, ; 74: System.Runtime.CompilerServices.Unsafe => 0x5423e47b => 27
	i32 1460219004, ; 75: Xamarin.Forms.Xaml => 0x57092c7c => 94
	i32 1462112819, ; 76: System.IO.Compression.dll => 0x57261233 => 110
	i32 1469204771, ; 77: Xamarin.AndroidX.AppCompat.AppCompatResources => 0x57924923 => 34
	i32 1550322496, ; 78: System.Reflection.Extensions.dll => 0x5c680b40 => 2
	i32 1582372066, ; 79: Xamarin.AndroidX.DocumentFile.dll => 0x5e5114e2 => 50
	i32 1592978981, ; 80: System.Runtime.Serialization.dll => 0x5ef2ee25 => 4
	i32 1622152042, ; 81: Xamarin.AndroidX.Loader.dll => 0x60b0136a => 67
	i32 1624863272, ; 82: Xamarin.AndroidX.ViewPager2 => 0x60d97228 => 89
	i32 1635184631, ; 83: Xamarin.AndroidX.Emoji2.ViewsHelper => 0x6176eff7 => 54
	i32 1636350590, ; 84: Xamarin.AndroidX.CursorAdapter => 0x6188ba7e => 48
	i32 1639515021, ; 85: System.Net.Http.dll => 0x61b9038d => 1
	i32 1657153582, ; 86: System.Runtime => 0x62c6282e => 28
	i32 1658241508, ; 87: Xamarin.AndroidX.Tracing.Tracing.dll => 0x62d6c1e4 => 83
	i32 1658251792, ; 88: Xamarin.Google.Android.Material.dll => 0x62d6ea10 => 95
	i32 1670060433, ; 89: Xamarin.AndroidX.ConstraintLayout => 0x638b1991 => 44
	i32 1698840827, ; 90: Xamarin.Kotlin.StdLib.Common => 0x654240fb => 98
	i32 1701541528, ; 91: System.Diagnostics.Debug.dll => 0x656b7698 => 114
	i32 1711441057, ; 92: SQLitePCLRaw.lib.e_sqlite3.android => 0x660284a1 => 18
	i32 1726116996, ; 93: System.Reflection.dll => 0x66e27484 => 115
	i32 1729485958, ; 94: Xamarin.AndroidX.CardView.dll => 0x6715dc86 => 40
	i32 1765942094, ; 95: System.Reflection.Extensions => 0x6942234e => 2
	i32 1766324549, ; 96: Xamarin.AndroidX.SwipeRefreshLayout => 0x6947f945 => 82
	i32 1776026572, ; 97: System.Core.dll => 0x69dc03cc => 21
	i32 1788241197, ; 98: Xamarin.AndroidX.Fragment => 0x6a96652d => 55
	i32 1808609942, ; 99: Xamarin.AndroidX.Loader => 0x6bcd3296 => 67
	i32 1813058853, ; 100: Xamarin.Kotlin.StdLib.dll => 0x6c111525 => 99
	i32 1813201214, ; 101: Xamarin.Google.Android.Material => 0x6c13413e => 95
	i32 1818569960, ; 102: Xamarin.AndroidX.Navigation.UI.dll => 0x6c652ce8 => 73
	i32 1867746548, ; 103: Xamarin.Essentials.dll => 0x6f538cf4 => 90
	i32 1878053835, ; 104: Xamarin.Forms.Xaml.dll => 0x6ff0d3cb => 94
	i32 1885316902, ; 105: Xamarin.AndroidX.Arch.Core.Runtime.dll => 0x705fa726 => 37
	i32 1904755420, ; 106: System.Runtime.InteropServices.WindowsRuntime.dll => 0x718842dc => 3
	i32 1919157823, ; 107: Xamarin.AndroidX.MultiDex.dll => 0x7264063f => 70
	i32 1983156543, ; 108: Xamarin.Kotlin.StdLib.Common.dll => 0x7634913f => 98
	i32 2011961780, ; 109: System.Buffers.dll => 0x77ec19b4 => 20
	i32 2019465201, ; 110: Xamarin.AndroidX.Lifecycle.ViewModel => 0x785e97f1 => 65
	i32 2055257422, ; 111: Xamarin.AndroidX.Lifecycle.LiveData.Core.dll => 0x7a80bd4e => 61
	i32 2079903147, ; 112: System.Runtime.dll => 0x7bf8cdab => 28
	i32 2090596640, ; 113: System.Numerics.Vectors => 0x7c9bf920 => 25
	i32 2097448633, ; 114: Xamarin.AndroidX.Legacy.Support.Core.UI => 0x7d0486b9 => 57
	i32 2103459038, ; 115: SQLitePCLRaw.provider.e_sqlite3.dll => 0x7d603cde => 19
	i32 2126786730, ; 116: Xamarin.Forms.Platform.Android => 0x7ec430aa => 92
	i32 2201107256, ; 117: Xamarin.KotlinX.Coroutines.Core.Jvm.dll => 0x83323b38 => 103
	i32 2201231467, ; 118: System.Net.Http => 0x8334206b => 1
	i32 2216717168, ; 119: Firebase.Auth.dll => 0x84206b70 => 6
	i32 2217644978, ; 120: Xamarin.AndroidX.VectorDrawable.Animated.dll => 0x842e93b2 => 85
	i32 2244775296, ; 121: Xamarin.AndroidX.LocalBroadcastManager => 0x85cc8d80 => 68
	i32 2256548716, ; 122: Xamarin.AndroidX.MultiDex => 0x8680336c => 70
	i32 2261435625, ; 123: Xamarin.AndroidX.Legacy.Support.V4.dll => 0x86cac4e9 => 59
	i32 2279755925, ; 124: Xamarin.AndroidX.RecyclerView.dll => 0x87e25095 => 77
	i32 2315684594, ; 125: Xamarin.AndroidX.Annotation.dll => 0x8a068af2 => 32
	i32 2403452196, ; 126: Xamarin.AndroidX.Emoji2.dll => 0x8f41c524 => 53
	i32 2409053734, ; 127: Xamarin.AndroidX.Preference.dll => 0x8f973e26 => 74
	i32 2439365897, ; 128: Base2.Android => 0x9165c509 => 0
	i32 2454642406, ; 129: System.Text.Encoding.dll => 0x924edee6 => 121
	i32 2465273461, ; 130: SQLitePCLRaw.batteries_v2.dll => 0x92f11675 => 16
	i32 2465532216, ; 131: Xamarin.AndroidX.ConstraintLayout.Core.dll => 0x92f50938 => 43
	i32 2471841756, ; 132: netstandard.dll => 0x93554fdc => 105
	i32 2475788418, ; 133: Java.Interop.dll => 0x93918882 => 9
	i32 2501346920, ; 134: System.Data.DataSetExtensions => 0x95178668 => 108
	i32 2505896520, ; 135: Xamarin.AndroidX.Lifecycle.Runtime.dll => 0x955cf248 => 64
	i32 2562349572, ; 136: Microsoft.CSharp => 0x98ba5a04 => 11
	i32 2581819634, ; 137: Xamarin.AndroidX.VectorDrawable.dll => 0x99e370f2 => 86
	i32 2605712449, ; 138: Xamarin.KotlinX.Coroutines.Core.Jvm => 0x9b500441 => 103
	i32 2620871830, ; 139: Xamarin.AndroidX.CursorAdapter.dll => 0x9c375496 => 48
	i32 2624644809, ; 140: Xamarin.AndroidX.DynamicAnimation => 0x9c70e6c9 => 52
	i32 2633051222, ; 141: Xamarin.AndroidX.Lifecycle.LiveData => 0x9cf12c56 => 62
	i32 2701096212, ; 142: Xamarin.AndroidX.Tracing.Tracing => 0xa0ff7514 => 83
	i32 2715334215, ; 143: System.Threading.Tasks.dll => 0xa1d8b647 => 116
	i32 2732626843, ; 144: Xamarin.AndroidX.Activity => 0xa2e0939b => 31
	i32 2737747696, ; 145: Xamarin.AndroidX.AppCompat.AppCompatResources.dll => 0xa32eb6f0 => 34
	i32 2766581644, ; 146: Xamarin.Forms.Core => 0xa4e6af8c => 91
	i32 2770495804, ; 147: Xamarin.Jetbrains.Annotations.dll => 0xa522693c => 97
	i32 2778768386, ; 148: Xamarin.AndroidX.ViewPager.dll => 0xa5a0a402 => 88
	i32 2779977773, ; 149: Xamarin.AndroidX.ResourceInspection.Annotation.dll => 0xa5b3182d => 78
	i32 2810250172, ; 150: Xamarin.AndroidX.CoordinatorLayout.dll => 0xa78103bc => 45
	i32 2819470561, ; 151: System.Xml.dll => 0xa80db4e1 => 29
	i32 2821294376, ; 152: Xamarin.AndroidX.ResourceInspection.Annotation => 0xa8298928 => 78
	i32 2833621920, ; 153: Base2.Android.dll => 0xa8e5a3a0 => 0
	i32 2853208004, ; 154: Xamarin.AndroidX.ViewPager => 0xaa107fc4 => 88
	i32 2855708567, ; 155: Xamarin.AndroidX.Transition => 0xaa36a797 => 84
	i32 2901442782, ; 156: System.Reflection => 0xacf080de => 115
	i32 2903344695, ; 157: System.ComponentModel.Composition => 0xad0d8637 => 112
	i32 2905242038, ; 158: mscorlib.dll => 0xad2a79b6 => 13
	i32 2916838712, ; 159: Xamarin.AndroidX.ViewPager2.dll => 0xaddb6d38 => 89
	i32 2919462931, ; 160: System.Numerics.Vectors.dll => 0xae037813 => 25
	i32 2921128767, ; 161: Xamarin.AndroidX.Annotation.Experimental.dll => 0xae1ce33f => 33
	i32 2978675010, ; 162: Xamarin.AndroidX.DrawerLayout => 0xb18af942 => 51
	i32 2996846495, ; 163: Xamarin.AndroidX.Lifecycle.Process.dll => 0xb2a03f9f => 63
	i32 3016983068, ; 164: Xamarin.AndroidX.Startup.StartupRuntime => 0xb3d3821c => 81
	i32 3024354802, ; 165: Xamarin.AndroidX.Legacy.Support.Core.Utils => 0xb443fdf2 => 58
	i32 3044182254, ; 166: FormsViewGroup => 0xb57288ee => 8
	i32 3057625584, ; 167: Xamarin.AndroidX.Navigation.Common => 0xb63fa9f0 => 71
	i32 3075834255, ; 168: System.Threading.Tasks => 0xb755818f => 116
	i32 3111772706, ; 169: System.Runtime.Serialization => 0xb979e222 => 4
	i32 3204380047, ; 170: System.Data.dll => 0xbefef58f => 106
	i32 3211777861, ; 171: Xamarin.AndroidX.DocumentFile => 0xbf6fd745 => 50
	i32 3220365878, ; 172: System.Threading => 0xbff2e236 => 120
	i32 3247949154, ; 173: Mono.Security => 0xc197c562 => 122
	i32 3258312781, ; 174: Xamarin.AndroidX.CardView => 0xc235e84d => 40
	i32 3267021929, ; 175: Xamarin.AndroidX.AsyncLayoutInflater => 0xc2bacc69 => 38
	i32 3286872994, ; 176: SQLite-net.dll => 0xc3e9b3a2 => 15
	i32 3299363146, ; 177: System.Text.Encoding => 0xc4a8494a => 121
	i32 3317135071, ; 178: Xamarin.AndroidX.CustomView.dll => 0xc5b776df => 49
	i32 3317144872, ; 179: System.Data => 0xc5b79d28 => 106
	i32 3322403133, ; 180: Firebase.dll => 0xc607d93d => 7
	i32 3340431453, ; 181: Xamarin.AndroidX.Arch.Core.Runtime => 0xc71af05d => 37
	i32 3345895724, ; 182: Xamarin.AndroidX.ProfileInstaller.ProfileInstaller.dll => 0xc76e512c => 76
	i32 3346324047, ; 183: Xamarin.AndroidX.Navigation.Runtime => 0xc774da4f => 72
	i32 3353484488, ; 184: Xamarin.AndroidX.Legacy.Support.Core.UI.dll => 0xc7e21cc8 => 57
	i32 3360279109, ; 185: SQLitePCLRaw.core => 0xc849ca45 => 17
	i32 3362522851, ; 186: Xamarin.AndroidX.Core => 0xc86c06e3 => 47
	i32 3366347497, ; 187: Java.Interop => 0xc8a662e9 => 9
	i32 3374999561, ; 188: Xamarin.AndroidX.RecyclerView => 0xc92a6809 => 77
	i32 3395150330, ; 189: System.Runtime.CompilerServices.Unsafe.dll => 0xca5de1fa => 27
	i32 3404865022, ; 190: System.ServiceModel.Internals => 0xcaf21dfe => 104
	i32 3429136800, ; 191: System.Xml => 0xcc6479a0 => 29
	i32 3430777524, ; 192: netstandard => 0xcc7d82b4 => 105
	i32 3441283291, ; 193: Xamarin.AndroidX.DynamicAnimation.dll => 0xcd1dd0db => 52
	i32 3476120550, ; 194: Mono.Android => 0xcf3163e6 => 12
	i32 3486566296, ; 195: System.Transactions => 0xcfd0c798 => 107
	i32 3493954962, ; 196: Xamarin.AndroidX.Concurrent.Futures.dll => 0xd0418592 => 42
	i32 3501239056, ; 197: Xamarin.AndroidX.AsyncLayoutInflater.dll => 0xd0b0ab10 => 38
	i32 3509114376, ; 198: System.Xml.Linq => 0xd128d608 => 30
	i32 3536029504, ; 199: Xamarin.Forms.Platform.Android.dll => 0xd2c38740 => 92
	i32 3567349600, ; 200: System.ComponentModel.Composition.dll => 0xd4a16f60 => 112
	i32 3596207933, ; 201: LiteDB.dll => 0xd659c73d => 10
	i32 3608519521, ; 202: System.Linq.dll => 0xd715a361 => 119
	i32 3618140916, ; 203: Xamarin.AndroidX.Preference => 0xd7a872f4 => 74
	i32 3627220390, ; 204: Xamarin.AndroidX.Print.dll => 0xd832fda6 => 75
	i32 3629588173, ; 205: LiteDB => 0xd8571ecd => 10
	i32 3632359727, ; 206: Xamarin.Forms.Platform => 0xd881692f => 93
	i32 3633644679, ; 207: Xamarin.AndroidX.Annotation.Experimental => 0xd8950487 => 33
	i32 3641597786, ; 208: Xamarin.AndroidX.Lifecycle.LiveData.Core => 0xd90e5f5a => 61
	i32 3672681054, ; 209: Mono.Android.dll => 0xdae8aa5e => 12
	i32 3676310014, ; 210: System.Web.Services.dll => 0xdb2009fe => 113
	i32 3682565725, ; 211: Xamarin.AndroidX.Browser => 0xdb7f7e5d => 39
	i32 3684561358, ; 212: Xamarin.AndroidX.Concurrent.Futures => 0xdb9df1ce => 42
	i32 3684933406, ; 213: System.Runtime.InteropServices.WindowsRuntime => 0xdba39f1e => 3
	i32 3689375977, ; 214: System.Drawing.Common => 0xdbe768e9 => 109
	i32 3706696989, ; 215: Xamarin.AndroidX.Core.Core.Ktx.dll => 0xdcefb51d => 46
	i32 3718780102, ; 216: Xamarin.AndroidX.Annotation => 0xdda814c6 => 32
	i32 3724971120, ; 217: Xamarin.AndroidX.Navigation.Common.dll => 0xde068c70 => 71
	i32 3731644420, ; 218: System.Reactive => 0xde6c6004 => 26
	i32 3754567612, ; 219: SQLitePCLRaw.provider.e_sqlite3 => 0xdfca27bc => 19
	i32 3758932259, ; 220: Xamarin.AndroidX.Legacy.Support.V4 => 0xe00cc123 => 59
	i32 3786282454, ; 221: Xamarin.AndroidX.Collection => 0xe1ae15d6 => 41
	i32 3822602673, ; 222: Xamarin.AndroidX.Media => 0xe3d849b1 => 69
	i32 3829621856, ; 223: System.Numerics.dll => 0xe4436460 => 24
	i32 3876362041, ; 224: SQLite-net => 0xe70c9739 => 15
	i32 3885922214, ; 225: Xamarin.AndroidX.Transition.dll => 0xe79e77a6 => 84
	i32 3888767677, ; 226: Xamarin.AndroidX.ProfileInstaller.ProfileInstaller => 0xe7c9e2bd => 76
	i32 3896760992, ; 227: Xamarin.AndroidX.Core.dll => 0xe843daa0 => 47
	i32 3920810846, ; 228: System.IO.Compression.FileSystem.dll => 0xe9b2d35e => 111
	i32 3921031405, ; 229: Xamarin.AndroidX.VersionedParcelable.dll => 0xe9b630ed => 87
	i32 3931092270, ; 230: Xamarin.AndroidX.Navigation.UI => 0xea4fb52e => 73
	i32 3945713374, ; 231: System.Data.DataSetExtensions.dll => 0xeb2ecede => 108
	i32 3955647286, ; 232: Xamarin.AndroidX.AppCompat.dll => 0xebc66336 => 35
	i32 3959773229, ; 233: Xamarin.AndroidX.Lifecycle.Process => 0xec05582d => 63
	i32 4024013275, ; 234: Firebase.Auth => 0xefd991db => 6
	i32 4025784931, ; 235: System.Memory => 0xeff49a63 => 23
	i32 4073602200, ; 236: System.Threading.dll => 0xf2ce3c98 => 120
	i32 4101593132, ; 237: Xamarin.AndroidX.Emoji2 => 0xf479582c => 53
	i32 4105002889, ; 238: Mono.Security.dll => 0xf4ad5f89 => 122
	i32 4114425875, ; 239: Base2.dll => 0xf53d2813 => 5
	i32 4151237749, ; 240: System.Core => 0xf76edc75 => 21
	i32 4181436372, ; 241: System.Runtime.Serialization.Primitives => 0xf93ba7d4 => 117
	i32 4182413190, ; 242: Xamarin.AndroidX.Lifecycle.ViewModelSavedState.dll => 0xf94a8f86 => 66
	i32 4256097574, ; 243: Xamarin.AndroidX.Core.Core.Ktx => 0xfdaee526 => 46
	i32 4260525087, ; 244: System.Buffers => 0xfdf2741f => 20
	i32 4292120959 ; 245: Xamarin.AndroidX.Lifecycle.ViewModelSavedState => 0xffd4917f => 66
], align 4
@assembly_image_cache_indices = local_unnamed_addr constant [246 x i32] [
	i32 64, i32 96, i32 14, i32 91, i32 80, i32 80, i32 100, i32 41, ; 0..7
	i32 82, i32 39, i32 114, i32 58, i32 11, i32 113, i32 44, i32 62, ; 8..15
	i32 56, i32 31, i32 24, i32 60, i32 18, i32 23, i32 7, i32 43, ; 16..23
	i32 90, i32 118, i32 55, i32 117, i32 13, i32 22, i32 56, i32 68, ; 24..31
	i32 107, i32 100, i32 111, i32 26, i32 49, i32 54, i32 87, i32 36, ; 32..39
	i32 30, i32 102, i32 97, i32 101, i32 16, i32 110, i32 109, i32 75, ; 40..47
	i32 96, i32 14, i32 101, i32 60, i32 8, i32 118, i32 79, i32 5, ; 48..55
	i32 35, i32 93, i32 65, i32 99, i32 22, i32 85, i32 72, i32 36, ; 56..63
	i32 81, i32 86, i32 102, i32 17, i32 51, i32 119, i32 104, i32 79, ; 64..71
	i32 69, i32 45, i32 27, i32 94, i32 110, i32 34, i32 2, i32 50, ; 72..79
	i32 4, i32 67, i32 89, i32 54, i32 48, i32 1, i32 28, i32 83, ; 80..87
	i32 95, i32 44, i32 98, i32 114, i32 18, i32 115, i32 40, i32 2, ; 88..95
	i32 82, i32 21, i32 55, i32 67, i32 99, i32 95, i32 73, i32 90, ; 96..103
	i32 94, i32 37, i32 3, i32 70, i32 98, i32 20, i32 65, i32 61, ; 104..111
	i32 28, i32 25, i32 57, i32 19, i32 92, i32 103, i32 1, i32 6, ; 112..119
	i32 85, i32 68, i32 70, i32 59, i32 77, i32 32, i32 53, i32 74, ; 120..127
	i32 0, i32 121, i32 16, i32 43, i32 105, i32 9, i32 108, i32 64, ; 128..135
	i32 11, i32 86, i32 103, i32 48, i32 52, i32 62, i32 83, i32 116, ; 136..143
	i32 31, i32 34, i32 91, i32 97, i32 88, i32 78, i32 45, i32 29, ; 144..151
	i32 78, i32 0, i32 88, i32 84, i32 115, i32 112, i32 13, i32 89, ; 152..159
	i32 25, i32 33, i32 51, i32 63, i32 81, i32 58, i32 8, i32 71, ; 160..167
	i32 116, i32 4, i32 106, i32 50, i32 120, i32 122, i32 40, i32 38, ; 168..175
	i32 15, i32 121, i32 49, i32 106, i32 7, i32 37, i32 76, i32 72, ; 176..183
	i32 57, i32 17, i32 47, i32 9, i32 77, i32 27, i32 104, i32 29, ; 184..191
	i32 105, i32 52, i32 12, i32 107, i32 42, i32 38, i32 30, i32 92, ; 192..199
	i32 112, i32 10, i32 119, i32 74, i32 75, i32 10, i32 93, i32 33, ; 200..207
	i32 61, i32 12, i32 113, i32 39, i32 42, i32 3, i32 109, i32 46, ; 208..215
	i32 32, i32 71, i32 26, i32 19, i32 59, i32 41, i32 69, i32 24, ; 216..223
	i32 15, i32 84, i32 76, i32 47, i32 111, i32 87, i32 73, i32 108, ; 224..231
	i32 35, i32 63, i32 6, i32 23, i32 120, i32 53, i32 122, i32 5, ; 232..239
	i32 21, i32 117, i32 66, i32 46, i32 20, i32 66 ; 240..245
], align 4

@marshal_methods_number_of_classes = local_unnamed_addr constant i32 0, align 4

; marshal_methods_class_cache
@marshal_methods_class_cache = global [0 x %struct.MarshalMethodsManagedClass] [
], align 4; end of 'marshal_methods_class_cache' array


@get_function_pointer = internal unnamed_addr global void (i32, i32, i32, i8**)* null, align 4

; Function attributes: "frame-pointer"="all" "min-legal-vector-width"="0" mustprogress nofree norecurse nosync "no-trapping-math"="true" nounwind sspstrong "stack-protector-buffer-size"="8" "target-cpu"="generic" "target-features"="+armv7-a,+d32,+dsp,+fp64,+neon,+thumb-mode,+vfp2,+vfp2sp,+vfp3,+vfp3d16,+vfp3d16sp,+vfp3sp,-aes,-fp-armv8,-fp-armv8d16,-fp-armv8d16sp,-fp-armv8sp,-fp16,-fp16fml,-fullfp16,-sha2,-vfp4,-vfp4d16,-vfp4d16sp,-vfp4sp" uwtable willreturn writeonly
define void @xamarin_app_init (void (i32, i32, i32, i8**)* %fn) local_unnamed_addr #0
{
	store void (i32, i32, i32, i8**)* %fn, void (i32, i32, i32, i8**)** @get_function_pointer, align 4
	ret void
}

; Names of classes in which marshal methods reside
@mm_class_names = local_unnamed_addr constant [0 x i8*] zeroinitializer, align 4
@__MarshalMethodName_name.0 = internal constant [1 x i8] c"\00", align 1

; mm_method_names
@mm_method_names = local_unnamed_addr constant [1 x %struct.MarshalMethodName] [
	; 0
	%struct.MarshalMethodName {
		i64 0, ; id 0x0; name: 
		i8* getelementptr inbounds ([1 x i8], [1 x i8]* @__MarshalMethodName_name.0, i32 0, i32 0); name
	}
], align 8; end of 'mm_method_names' array


attributes #0 = { "min-legal-vector-width"="0" mustprogress nofree norecurse nosync "no-trapping-math"="true" nounwind sspstrong "stack-protector-buffer-size"="8" uwtable willreturn writeonly "frame-pointer"="all" "target-cpu"="generic" "target-features"="+armv7-a,+d32,+dsp,+fp64,+neon,+thumb-mode,+vfp2,+vfp2sp,+vfp3,+vfp3d16,+vfp3d16sp,+vfp3sp,-aes,-fp-armv8,-fp-armv8d16,-fp-armv8d16sp,-fp-armv8sp,-fp16,-fp16fml,-fullfp16,-sha2,-vfp4,-vfp4d16,-vfp4d16sp,-vfp4sp" }
attributes #1 = { "min-legal-vector-width"="0" mustprogress "no-trapping-math"="true" nounwind sspstrong "stack-protector-buffer-size"="8" uwtable "frame-pointer"="all" "target-cpu"="generic" "target-features"="+armv7-a,+d32,+dsp,+fp64,+neon,+thumb-mode,+vfp2,+vfp2sp,+vfp3,+vfp3d16,+vfp3d16sp,+vfp3sp,-aes,-fp-armv8,-fp-armv8d16,-fp-armv8d16sp,-fp-armv8sp,-fp16,-fp16fml,-fullfp16,-sha2,-vfp4,-vfp4d16,-vfp4d16sp,-vfp4sp" }
attributes #2 = { nounwind }

!llvm.module.flags = !{!0, !1, !2}
!llvm.ident = !{!3}
!0 = !{i32 1, !"wchar_size", i32 4}
!1 = !{i32 7, !"PIC Level", i32 2}
!2 = !{i32 1, !"min_enum_size", i32 4}
!3 = !{!"Xamarin.Android remotes/origin/d17-5 @ 45b0e144f73b2c8747d8b5ec8cbd3b55beca67f0"}
!llvm.linker.options = !{}
