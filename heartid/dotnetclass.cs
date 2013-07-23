/*
* MATLAB Compiler: 4.9 (R2008b)
* Date: Thu Mar 17 13:01:22 2011
* Arguments: "-B" "macro_default" "-W" "dotnet:dotnet,dotnetclass,0.0,private" "-d"
* "D:\School_Work\Design_Project\Conversion_individual\dotnet\" "-T" "link:lib"
* "class{dotnetclass:D:\School_Work\Design_Project\Conversion_individual\process.m,D:\Scho
* ol_Work\Design_Project\Conversion_individual\dlda.m,D:\School_Work\Design_Project\Conver
* sion_individual\classify_input.m,D:\School_Work\Design_Project\Conversion_individual\F_E
* igenSys.m,D:\School_Work\Design_Project\Conversion_individual\addtogallery.m,D:\School_W
* ork\Design_Project\Conversion_individual\addtoid.m,D:\School_Work\Design_Project\Convers
* ion_individual\projection.m,D:\School_Work\Design_Project\Conversion_individual\delete_g
* allery.m,D:\School_Work\Design_Project\Conversion_individual\delete_id.m,D:\School_Work\
* Design_Project\Conversion_individual\authentication.m,D:\School_Work\Design_Project\Conv
* ersion_individual\claim_gallery.m}" 
*/

using System;
using System.Reflection;
using System.IO;
using MathWorks.MATLAB.NET.Arrays;
using MathWorks.MATLAB.NET.Utility;
using MathWorks.MATLAB.NET.ComponentData;
#if SHARED
[assembly: System.Reflection.AssemblyKeyFile(@"")]
#endif

namespace dotnet
{
  /// <summary>
  /// The dotnetclass class provides a CLS compliant, MWArray interface to the
  /// M-functions contained in the files:
  /// <newpara></newpara>
  /// D:\School_Work\Design_Project\Conversion_individual\process.m
  /// <newpara></newpara>
  /// D:\School_Work\Design_Project\Conversion_individual\dlda.m
  /// <newpara></newpara>
  /// D:\School_Work\Design_Project\Conversion_individual\classify_input.m
  /// <newpara></newpara>
  /// D:\School_Work\Design_Project\Conversion_individual\F_EigenSys.m
  /// <newpara></newpara>
  /// D:\School_Work\Design_Project\Conversion_individual\addtogallery.m
  /// <newpara></newpara>
  /// D:\School_Work\Design_Project\Conversion_individual\addtoid.m
  /// <newpara></newpara>
  /// D:\School_Work\Design_Project\Conversion_individual\projection.m
  /// <newpara></newpara>
  /// D:\School_Work\Design_Project\Conversion_individual\delete_gallery.m
  /// <newpara></newpara>
  /// D:\School_Work\Design_Project\Conversion_individual\delete_id.m
  /// <newpara></newpara>
  /// D:\School_Work\Design_Project\Conversion_individual\authentication.m
  /// <newpara></newpara>
  /// D:\School_Work\Design_Project\Conversion_individual\claim_gallery.m
  /// <newpara></newpara>
  /// deployprint.m
  /// <newpara></newpara>
  /// printdlg.m
  /// </summary>
  /// <remarks>
  /// @Version 0.0
  /// </remarks>
  public class dotnetclass : IDisposable
  {
      #region Constructors

      /// <summary internal= "true">
      /// The static constructor instantiates and initializes the MATLAB Component
      /// Runtime instance.
      /// </summary>
      static dotnetclass()
      {
          if (MWArray.MCRAppInitialized)
          {
              Assembly assembly= Assembly.GetExecutingAssembly();

              string ctfFilePath= assembly.Location;

              int lastDelimeter= ctfFilePath.LastIndexOf(@"\");

              ctfFilePath= ctfFilePath.Remove(lastDelimeter, (ctfFilePath.Length - lastDelimeter));

              string ctfFileName = MCRComponentState.MCC_dotnet_name_data + ".ctf";

              Stream embeddedCtfStream = null;

              String[] resourceStrings = assembly.GetManifestResourceNames();

              foreach (String name in resourceStrings)
                {
                  if (name.Contains(ctfFileName))
                    {
                      embeddedCtfStream = assembly.GetManifestResourceStream(name);
                      break;
                    }
                }
              mcr= new MWMCR(MCRComponentState.MCC_dotnet_name_data,
                             MCRComponentState.MCC_dotnet_root_data,
                             MCRComponentState.MCC_dotnet_public_data,
                             MCRComponentState.MCC_dotnet_session_data,
                             MCRComponentState.MCC_dotnet_matlabpath_data,
                             MCRComponentState.MCC_dotnet_classpath_data,
                             MCRComponentState.MCC_dotnet_libpath_data,
                             MCRComponentState.MCC_dotnet_mcr_application_options,
                             MCRComponentState.MCC_dotnet_mcr_runtime_options,
                             MCRComponentState.MCC_dotnet_mcr_pref_dir,
                             MCRComponentState.MCC_dotnet_set_warning_state,
                             ctfFilePath, embeddedCtfStream, true);
          }
          else
          {
              throw new ApplicationException("MWArray assembly could not be initialized");
          }
      }


      /// <summary>
      /// Constructs a new instance of the dotnetclass class.
      /// </summary>
      public dotnetclass()
      {
      }


      #endregion Constructors

      #region Finalize

      /// <summary internal= "true">
      /// Class destructor called by the CLR garbage collector.
      /// </summary>
      ~dotnetclass()
      {
          Dispose(false);
      }


      /// <summary>
      /// Frees the native resources associated with this object
      /// </summary>
      public void Dispose()
      {
          Dispose(true);

          GC.SuppressFinalize(this);
      }


      /// <summary internal= "true">
      /// Internal dispose function
      /// </summary>
      protected virtual void Dispose(bool disposing)
      {
          if (!disposed)
          {
              disposed= true;

              if (disposing)
              {
                  // Free managed resources;
              }

              // Free native resources
          }
      }


      #endregion Finalize

      #region Methods

      /// <summary>
      /// Provides a single output, 0-input MWArray interface to the process M-function.
      /// </summary>
      /// <remarks>
      /// M-Documentation:
      /// takes an ecg, filters and gives you a segment of the autocorrelation
      /// create a filter
      /// </remarks>
      /// <returns>An MWArray containing the first output argument.</returns>
      ///
      public MWArray process()
      {
          return mcr.EvaluateFunction("process", new MWArray[]{});
      }


      /// <summary>
      /// Provides a single output, 1-input MWArray interface to the process M-function.
      /// </summary>
      /// <remarks>
      /// M-Documentation:
      /// takes an ecg, filters and gives you a segment of the autocorrelation
      /// create a filter
      /// </remarks>
      /// <param name="input">Input argument #1</param>
      /// <returns>An MWArray containing the first output argument.</returns>
      ///
      public MWArray process(MWArray input)
      {
          return mcr.EvaluateFunction("process", input);
      }


      /// <summary>
      /// Provides a single output, 2-input MWArray interface to the process M-function.
      /// </summary>
      /// <remarks>
      /// M-Documentation:
      /// takes an ecg, filters and gives you a segment of the autocorrelation
      /// create a filter
      /// </remarks>
      /// <param name="input">Input argument #1</param>
      /// <param name="M">Input argument #2</param>
      /// <returns>An MWArray containing the first output argument.</returns>
      ///
      public MWArray process(MWArray input, MWArray M)
      {
          return mcr.EvaluateFunction("process", input, M);
      }


      /// <summary>
      /// Provides the standard 0-input MWArray interface to the process M-function.
      /// </summary>
      /// <remarks>
      /// M-Documentation:
      /// takes an ecg, filters and gives you a segment of the autocorrelation
      /// create a filter
      /// </remarks>
      /// <param name="numArgsOut">The number of output arguments to return.</param>
      /// <returns>An Array of length "numArgsOut" containing the output
      /// arguments.</returns>
      ///
      public MWArray[] process(int numArgsOut)
      {
          return mcr.EvaluateFunction(numArgsOut, "process", new MWArray[]{});
      }


      /// <summary>
      /// Provides the standard 1-input MWArray interface to the process M-function.
      /// </summary>
      /// <remarks>
      /// M-Documentation:
      /// takes an ecg, filters and gives you a segment of the autocorrelation
      /// create a filter
      /// </remarks>
      /// <param name="numArgsOut">The number of output arguments to return.</param>
      /// <param name="input">Input argument #1</param>
      /// <returns>An Array of length "numArgsOut" containing the output
      /// arguments.</returns>
      ///
      public MWArray[] process(int numArgsOut, MWArray input)
      {
          return mcr.EvaluateFunction(numArgsOut, "process", input);
      }


      /// <summary>
      /// Provides the standard 2-input MWArray interface to the process M-function.
      /// </summary>
      /// <remarks>
      /// M-Documentation:
      /// takes an ecg, filters and gives you a segment of the autocorrelation
      /// create a filter
      /// </remarks>
      /// <param name="numArgsOut">The number of output arguments to return.</param>
      /// <param name="input">Input argument #1</param>
      /// <param name="M">Input argument #2</param>
      /// <returns>An Array of length "numArgsOut" containing the output
      /// arguments.</returns>
      ///
      public MWArray[] process(int numArgsOut, MWArray input, MWArray M)
      {
          return mcr.EvaluateFunction(numArgsOut, "process", input, M);
      }


      /// <summary>
      /// Provides an interface for the process function in which the input and output
      /// arguments are specified as an array of MWArrays.
      /// </summary>
      /// <remarks>
      /// This method will allocate and return by reference the output argument
      /// array.<newpara></newpara>
      /// M-Documentation:
      /// takes an ecg, filters and gives you a segment of the autocorrelation
      /// create a filter
      /// </remarks>
      /// <param name="numArgsOut">The number of output arguments to return</param>
      /// <param name= "argsOut">Array of MWArray output arguments</param>
      /// <param name= "argsIn">Array of MWArray input arguments</param>
      ///
      public void process(int numArgsOut, ref MWArray[] argsOut, MWArray[] argsIn)
      {
          mcr.EvaluateFunction("process", numArgsOut, ref argsOut, argsIn);
      }


      /// <summary>
      /// Provides a single output, 0-input MWArray interface to the dlda M-function.
      /// </summary>
      /// <remarks>
      /// M-Documentation:
      /// class mean
      /// </remarks>
      /// <returns>An MWArray containing the first output argument.</returns>
      ///
      public MWArray dlda()
      {
          return mcr.EvaluateFunction("dlda", new MWArray[]{});
      }


      /// <summary>
      /// Provides a single output, 1-input MWArray interface to the dlda M-function.
      /// </summary>
      /// <remarks>
      /// M-Documentation:
      /// class mean
      /// </remarks>
      /// <param name="trainx">Input argument #1</param>
      /// <returns>An MWArray containing the first output argument.</returns>
      ///
      public MWArray dlda(MWArray trainx)
      {
          return mcr.EvaluateFunction("dlda", trainx);
      }


      /// <summary>
      /// Provides a single output, 2-input MWArray interface to the dlda M-function.
      /// </summary>
      /// <remarks>
      /// M-Documentation:
      /// class mean
      /// </remarks>
      /// <param name="trainx">Input argument #1</param>
      /// <param name="trainy">Input argument #2</param>
      /// <returns>An MWArray containing the first output argument.</returns>
      ///
      public MWArray dlda(MWArray trainx, MWArray trainy)
      {
          return mcr.EvaluateFunction("dlda", trainx, trainy);
      }


      /// <summary>
      /// Provides the standard 0-input MWArray interface to the dlda M-function.
      /// </summary>
      /// <remarks>
      /// M-Documentation:
      /// class mean
      /// </remarks>
      /// <param name="numArgsOut">The number of output arguments to return.</param>
      /// <returns>An Array of length "numArgsOut" containing the output
      /// arguments.</returns>
      ///
      public MWArray[] dlda(int numArgsOut)
      {
          return mcr.EvaluateFunction(numArgsOut, "dlda", new MWArray[]{});
      }


      /// <summary>
      /// Provides the standard 1-input MWArray interface to the dlda M-function.
      /// </summary>
      /// <remarks>
      /// M-Documentation:
      /// class mean
      /// </remarks>
      /// <param name="numArgsOut">The number of output arguments to return.</param>
      /// <param name="trainx">Input argument #1</param>
      /// <returns>An Array of length "numArgsOut" containing the output
      /// arguments.</returns>
      ///
      public MWArray[] dlda(int numArgsOut, MWArray trainx)
      {
          return mcr.EvaluateFunction(numArgsOut, "dlda", trainx);
      }


      /// <summary>
      /// Provides the standard 2-input MWArray interface to the dlda M-function.
      /// </summary>
      /// <remarks>
      /// M-Documentation:
      /// class mean
      /// </remarks>
      /// <param name="numArgsOut">The number of output arguments to return.</param>
      /// <param name="trainx">Input argument #1</param>
      /// <param name="trainy">Input argument #2</param>
      /// <returns>An Array of length "numArgsOut" containing the output
      /// arguments.</returns>
      ///
      public MWArray[] dlda(int numArgsOut, MWArray trainx, MWArray trainy)
      {
          return mcr.EvaluateFunction(numArgsOut, "dlda", trainx, trainy);
      }


      /// <summary>
      /// Provides an interface for the dlda function in which the input and output
      /// arguments are specified as an array of MWArrays.
      /// </summary>
      /// <remarks>
      /// This method will allocate and return by reference the output argument
      /// array.<newpara></newpara>
      /// M-Documentation:
      /// class mean
      /// </remarks>
      /// <param name="numArgsOut">The number of output arguments to return</param>
      /// <param name= "argsOut">Array of MWArray output arguments</param>
      /// <param name= "argsIn">Array of MWArray input arguments</param>
      ///
      public void dlda(int numArgsOut, ref MWArray[] argsOut, MWArray[] argsIn)
      {
          mcr.EvaluateFunction("dlda", numArgsOut, ref argsOut, argsIn);
      }


      /// <summary>
      /// Provides a single output, 0-input MWArray interface to the classify_input
      /// M-function.
      /// </summary>
      /// <remarks>
      /// M-Documentation:
      /// top three
      /// </remarks>
      /// <returns>An MWArray containing the first output argument.</returns>
      ///
      public MWArray classify_input()
      {
          return mcr.EvaluateFunction("classify_input", new MWArray[]{});
      }


      /// <summary>
      /// Provides a single output, 1-input MWArray interface to the classify_input
      /// M-function.
      /// </summary>
      /// <remarks>
      /// M-Documentation:
      /// top three
      /// </remarks>
      /// <param name="input">Input argument #1</param>
      /// <returns>An MWArray containing the first output argument.</returns>
      ///
      public MWArray classify_input(MWArray input)
      {
          return mcr.EvaluateFunction("classify_input", input);
      }


      /// <summary>
      /// Provides a single output, 2-input MWArray interface to the classify_input
      /// M-function.
      /// </summary>
      /// <remarks>
      /// M-Documentation:
      /// top three
      /// </remarks>
      /// <param name="input">Input argument #1</param>
      /// <param name="gallery">Input argument #2</param>
      /// <returns>An MWArray containing the first output argument.</returns>
      ///
      public MWArray classify_input(MWArray input, MWArray gallery)
      {
          return mcr.EvaluateFunction("classify_input", input, gallery);
      }


      /// <summary>
      /// Provides a single output, 3-input MWArray interface to the classify_input
      /// M-function.
      /// </summary>
      /// <remarks>
      /// M-Documentation:
      /// top three
      /// </remarks>
      /// <param name="input">Input argument #1</param>
      /// <param name="gallery">Input argument #2</param>
      /// <param name="id">Input argument #3</param>
      /// <returns>An MWArray containing the first output argument.</returns>
      ///
      public MWArray classify_input(MWArray input, MWArray gallery, MWArray id)
      {
          return mcr.EvaluateFunction("classify_input", input, gallery, id);
      }


      /// <summary>
      /// Provides the standard 0-input MWArray interface to the classify_input
      /// M-function.
      /// </summary>
      /// <remarks>
      /// M-Documentation:
      /// top three
      /// </remarks>
      /// <param name="numArgsOut">The number of output arguments to return.</param>
      /// <returns>An Array of length "numArgsOut" containing the output
      /// arguments.</returns>
      ///
      public MWArray[] classify_input(int numArgsOut)
      {
          return mcr.EvaluateFunction(numArgsOut,
                                      "classify_input", new MWArray[]{});
      }


      /// <summary>
      /// Provides the standard 1-input MWArray interface to the classify_input
      /// M-function.
      /// </summary>
      /// <remarks>
      /// M-Documentation:
      /// top three
      /// </remarks>
      /// <param name="numArgsOut">The number of output arguments to return.</param>
      /// <param name="input">Input argument #1</param>
      /// <returns>An Array of length "numArgsOut" containing the output
      /// arguments.</returns>
      ///
      public MWArray[] classify_input(int numArgsOut, MWArray input)
      {
          return mcr.EvaluateFunction(numArgsOut, "classify_input", input);
      }


      /// <summary>
      /// Provides the standard 2-input MWArray interface to the classify_input
      /// M-function.
      /// </summary>
      /// <remarks>
      /// M-Documentation:
      /// top three
      /// </remarks>
      /// <param name="numArgsOut">The number of output arguments to return.</param>
      /// <param name="input">Input argument #1</param>
      /// <param name="gallery">Input argument #2</param>
      /// <returns>An Array of length "numArgsOut" containing the output
      /// arguments.</returns>
      ///
      public MWArray[] classify_input(int numArgsOut, MWArray input,
                                      MWArray gallery)
      {
          return mcr.EvaluateFunction(numArgsOut, "classify_input",
                                      input, gallery);
      }


      /// <summary>
      /// Provides the standard 3-input MWArray interface to the classify_input
      /// M-function.
      /// </summary>
      /// <remarks>
      /// M-Documentation:
      /// top three
      /// </remarks>
      /// <param name="numArgsOut">The number of output arguments to return.</param>
      /// <param name="input">Input argument #1</param>
      /// <param name="gallery">Input argument #2</param>
      /// <param name="id">Input argument #3</param>
      /// <returns>An Array of length "numArgsOut" containing the output
      /// arguments.</returns>
      ///
      public MWArray[] classify_input(int numArgsOut, MWArray input,
                                      MWArray gallery, MWArray id)
      {
          return mcr.EvaluateFunction(numArgsOut, "classify_input",
                                      input, gallery, id);
      }


      /// <summary>
      /// Provides an interface for the classify_input function in which the input and
      /// output
      /// arguments are specified as an array of MWArrays.
      /// </summary>
      /// <remarks>
      /// This method will allocate and return by reference the output argument
      /// array.<newpara></newpara>
      /// M-Documentation:
      /// top three
      /// </remarks>
      /// <param name="numArgsOut">The number of output arguments to return</param>
      /// <param name= "argsOut">Array of MWArray output arguments</param>
      /// <param name= "argsIn">Array of MWArray input arguments</param>
      ///
      public void classify_input(int numArgsOut, ref MWArray[] argsOut,
                           MWArray[] argsIn)
      {
          mcr.EvaluateFunction("classify_input", numArgsOut, ref argsOut, argsIn);
      }


      /// <summary>
      /// Provides a single output, 0-input MWArray interface to the F_EigenSys
      /// M-function.
      /// </summary>
      /// <remarks>
      /// M-Documentation:
      /// Syntax: [eVec,eVal]=F_EigenSys(M);
      /// - Eigen values and vectors of M, sorted by decreasing eigen values.
      /// Author: Lu Juwei - U of Toronto
      /// Created in 27 May 2001
      /// Modified in 6 August 2003
      /// </remarks>
      /// <returns>An MWArray containing the first output argument.</returns>
      ///
      public MWArray F_EigenSys()
      {
          return mcr.EvaluateFunction("F_EigenSys", new MWArray[]{});
      }


      /// <summary>
      /// Provides a single output, 1-input MWArray interface to the F_EigenSys
      /// M-function.
      /// </summary>
      /// <remarks>
      /// M-Documentation:
      /// Syntax: [eVec,eVal]=F_EigenSys(M);
      /// - Eigen values and vectors of M, sorted by decreasing eigen values.
      /// Author: Lu Juwei - U of Toronto
      /// Created in 27 May 2001
      /// Modified in 6 August 2003
      /// </remarks>
      /// <param name="M">Input argument #1</param>
      /// <returns>An MWArray containing the first output argument.</returns>
      ///
      public MWArray F_EigenSys(MWArray M)
      {
          return mcr.EvaluateFunction("F_EigenSys", M);
      }


      /// <summary>
      /// Provides the standard 0-input MWArray interface to the F_EigenSys M-function.
      /// </summary>
      /// <remarks>
      /// M-Documentation:
      /// Syntax: [eVec,eVal]=F_EigenSys(M);
      /// - Eigen values and vectors of M, sorted by decreasing eigen values.
      /// Author: Lu Juwei - U of Toronto
      /// Created in 27 May 2001
      /// Modified in 6 August 2003
      /// </remarks>
      /// <param name="numArgsOut">The number of output arguments to return.</param>
      /// <returns>An Array of length "numArgsOut" containing the output
      /// arguments.</returns>
      ///
      public MWArray[] F_EigenSys(int numArgsOut)
      {
          return mcr.EvaluateFunction(numArgsOut,
                                      "F_EigenSys", new MWArray[]{});
      }


      /// <summary>
      /// Provides the standard 1-input MWArray interface to the F_EigenSys M-function.
      /// </summary>
      /// <remarks>
      /// M-Documentation:
      /// Syntax: [eVec,eVal]=F_EigenSys(M);
      /// - Eigen values and vectors of M, sorted by decreasing eigen values.
      /// Author: Lu Juwei - U of Toronto
      /// Created in 27 May 2001
      /// Modified in 6 August 2003
      /// </remarks>
      /// <param name="numArgsOut">The number of output arguments to return.</param>
      /// <param name="M">Input argument #1</param>
      /// <returns>An Array of length "numArgsOut" containing the output
      /// arguments.</returns>
      ///
      public MWArray[] F_EigenSys(int numArgsOut, MWArray M)
      {
          return mcr.EvaluateFunction(numArgsOut, "F_EigenSys", M);
      }


      /// <summary>
      /// Provides an interface for the F_EigenSys function in which the input and output
      /// arguments are specified as an array of MWArrays.
      /// </summary>
      /// <remarks>
      /// This method will allocate and return by reference the output argument
      /// array.<newpara></newpara>
      /// M-Documentation:
      /// Syntax: [eVec,eVal]=F_EigenSys(M);
      /// - Eigen values and vectors of M, sorted by decreasing eigen values.
      /// Author: Lu Juwei - U of Toronto
      /// Created in 27 May 2001
      /// Modified in 6 August 2003
      /// </remarks>
      /// <param name="numArgsOut">The number of output arguments to return</param>
      /// <param name= "argsOut">Array of MWArray output arguments</param>
      /// <param name= "argsIn">Array of MWArray input arguments</param>
      ///
      public void F_EigenSys(int numArgsOut, ref MWArray[] argsOut, MWArray[] argsIn)
      {
          mcr.EvaluateFunction("F_EigenSys", numArgsOut, ref argsOut, argsIn);
      }


      /// <summary>
      /// Provides a single output, 0-input MWArray interface to the addtogallery
      /// M-function.
      /// </summary>
      /// <remarks>
      /// </remarks>
      /// <returns>An MWArray containing the first output argument.</returns>
      ///
      public MWArray addtogallery()
      {
          return mcr.EvaluateFunction("addtogallery", new MWArray[]{});
      }


      /// <summary>
      /// Provides a single output, 1-input MWArray interface to the addtogallery
      /// M-function.
      /// </summary>
      /// <remarks>
      /// </remarks>
      /// <param name="gal">Input argument #1</param>
      /// <returns>An MWArray containing the first output argument.</returns>
      ///
      public MWArray addtogallery(MWArray gal)
      {
          return mcr.EvaluateFunction("addtogallery", gal);
      }


      /// <summary>
      /// Provides a single output, 2-input MWArray interface to the addtogallery
      /// M-function.
      /// </summary>
      /// <remarks>
      /// </remarks>
      /// <param name="gal">Input argument #1</param>
      /// <param name="addition">Input argument #2</param>
      /// <returns>An MWArray containing the first output argument.</returns>
      ///
      public MWArray addtogallery(MWArray gal, MWArray addition)
      {
          return mcr.EvaluateFunction("addtogallery", gal, addition);
      }


      /// <summary>
      /// Provides the standard 0-input MWArray interface to the addtogallery M-function.
      /// </summary>
      /// <remarks>
      /// </remarks>
      /// <param name="numArgsOut">The number of output arguments to return.</param>
      /// <returns>An Array of length "numArgsOut" containing the output
      /// arguments.</returns>
      ///
      public MWArray[] addtogallery(int numArgsOut)
      {
          return mcr.EvaluateFunction(numArgsOut,
                                      "addtogallery", new MWArray[]{});
      }


      /// <summary>
      /// Provides the standard 1-input MWArray interface to the addtogallery M-function.
      /// </summary>
      /// <remarks>
      /// </remarks>
      /// <param name="numArgsOut">The number of output arguments to return.</param>
      /// <param name="gal">Input argument #1</param>
      /// <returns>An Array of length "numArgsOut" containing the output
      /// arguments.</returns>
      ///
      public MWArray[] addtogallery(int numArgsOut, MWArray gal)
      {
          return mcr.EvaluateFunction(numArgsOut, "addtogallery", gal);
      }


      /// <summary>
      /// Provides the standard 2-input MWArray interface to the addtogallery M-function.
      /// </summary>
      /// <remarks>
      /// </remarks>
      /// <param name="numArgsOut">The number of output arguments to return.</param>
      /// <param name="gal">Input argument #1</param>
      /// <param name="addition">Input argument #2</param>
      /// <returns>An Array of length "numArgsOut" containing the output
      /// arguments.</returns>
      ///
      public MWArray[] addtogallery(int numArgsOut, MWArray gal,
                                    MWArray addition)
      {
          return mcr.EvaluateFunction(numArgsOut, "addtogallery",
                                      gal, addition);
      }


      /// <summary>
      /// Provides an interface for the addtogallery function in which the input and
      /// output
      /// arguments are specified as an array of MWArrays.
      /// </summary>
      /// <remarks>
      /// This method will allocate and return by reference the output argument
      /// array.<newpara></newpara>
      /// </remarks>
      /// <param name="numArgsOut">The number of output arguments to return</param>
      /// <param name= "argsOut">Array of MWArray output arguments</param>
      /// <param name= "argsIn">Array of MWArray input arguments</param>
      ///
      public void addtogallery(int numArgsOut, ref MWArray[] argsOut,
                         MWArray[] argsIn)
      {
          mcr.EvaluateFunction("addtogallery", numArgsOut, ref argsOut, argsIn);
      }


      /// <summary>
      /// Provides a single output, 0-input MWArray interface to the addtoid M-function.
      /// </summary>
      /// <remarks>
      /// </remarks>
      /// <returns>An MWArray containing the first output argument.</returns>
      ///
      public MWArray addtoid()
      {
          return mcr.EvaluateFunction("addtoid", new MWArray[]{});
      }


      /// <summary>
      /// Provides a single output, 1-input MWArray interface to the addtoid M-function.
      /// </summary>
      /// <remarks>
      /// </remarks>
      /// <param name="id">Input argument #1</param>
      /// <returns>An MWArray containing the first output argument.</returns>
      ///
      public MWArray addtoid(MWArray id)
      {
          return mcr.EvaluateFunction("addtoid", id);
      }


      /// <summary>
      /// Provides a single output, 2-input MWArray interface to the addtoid M-function.
      /// </summary>
      /// <remarks>
      /// </remarks>
      /// <param name="id">Input argument #1</param>
      /// <param name="subj_id">Input argument #2</param>
      /// <returns>An MWArray containing the first output argument.</returns>
      ///
      public MWArray addtoid(MWArray id, MWArray subj_id)
      {
          return mcr.EvaluateFunction("addtoid", id, subj_id);
      }


      /// <summary>
      /// Provides the standard 0-input MWArray interface to the addtoid M-function.
      /// </summary>
      /// <remarks>
      /// </remarks>
      /// <param name="numArgsOut">The number of output arguments to return.</param>
      /// <returns>An Array of length "numArgsOut" containing the output
      /// arguments.</returns>
      ///
      public MWArray[] addtoid(int numArgsOut)
      {
          return mcr.EvaluateFunction(numArgsOut, "addtoid", new MWArray[]{});
      }


      /// <summary>
      /// Provides the standard 1-input MWArray interface to the addtoid M-function.
      /// </summary>
      /// <remarks>
      /// </remarks>
      /// <param name="numArgsOut">The number of output arguments to return.</param>
      /// <param name="id">Input argument #1</param>
      /// <returns>An Array of length "numArgsOut" containing the output
      /// arguments.</returns>
      ///
      public MWArray[] addtoid(int numArgsOut, MWArray id)
      {
          return mcr.EvaluateFunction(numArgsOut, "addtoid", id);
      }


      /// <summary>
      /// Provides the standard 2-input MWArray interface to the addtoid M-function.
      /// </summary>
      /// <remarks>
      /// </remarks>
      /// <param name="numArgsOut">The number of output arguments to return.</param>
      /// <param name="id">Input argument #1</param>
      /// <param name="subj_id">Input argument #2</param>
      /// <returns>An Array of length "numArgsOut" containing the output
      /// arguments.</returns>
      ///
      public MWArray[] addtoid(int numArgsOut, MWArray id, MWArray subj_id)
      {
          return mcr.EvaluateFunction(numArgsOut, "addtoid", id, subj_id);
      }


      /// <summary>
      /// Provides an interface for the addtoid function in which the input and output
      /// arguments are specified as an array of MWArrays.
      /// </summary>
      /// <remarks>
      /// This method will allocate and return by reference the output argument
      /// array.<newpara></newpara>
      /// </remarks>
      /// <param name="numArgsOut">The number of output arguments to return</param>
      /// <param name= "argsOut">Array of MWArray output arguments</param>
      /// <param name= "argsIn">Array of MWArray input arguments</param>
      ///
      public void addtoid(int numArgsOut, ref MWArray[] argsOut, MWArray[] argsIn)
      {
          mcr.EvaluateFunction("addtoid", numArgsOut, ref argsOut, argsIn);
      }


      /// <summary>
      /// Provides a single output, 0-input MWArray interface to the projection
      /// M-function.
      /// </summary>
      /// <remarks>
      /// </remarks>
      /// <returns>An MWArray containing the first output argument.</returns>
      ///
      public MWArray projection()
      {
          return mcr.EvaluateFunction("projection", new MWArray[]{});
      }


      /// <summary>
      /// Provides a single output, 1-input MWArray interface to the projection
      /// M-function.
      /// </summary>
      /// <remarks>
      /// </remarks>
      /// <param name="input">Input argument #1</param>
      /// <returns>An MWArray containing the first output argument.</returns>
      ///
      public MWArray projection(MWArray input)
      {
          return mcr.EvaluateFunction("projection", input);
      }


      /// <summary>
      /// Provides a single output, 2-input MWArray interface to the projection
      /// M-function.
      /// </summary>
      /// <remarks>
      /// </remarks>
      /// <param name="input">Input argument #1</param>
      /// <param name="weight">Input argument #2</param>
      /// <returns>An MWArray containing the first output argument.</returns>
      ///
      public MWArray projection(MWArray input, MWArray weight)
      {
          return mcr.EvaluateFunction("projection", input, weight);
      }


      /// <summary>
      /// Provides the standard 0-input MWArray interface to the projection M-function.
      /// </summary>
      /// <remarks>
      /// </remarks>
      /// <param name="numArgsOut">The number of output arguments to return.</param>
      /// <returns>An Array of length "numArgsOut" containing the output
      /// arguments.</returns>
      ///
      public MWArray[] projection(int numArgsOut)
      {
          return mcr.EvaluateFunction(numArgsOut,
                                      "projection", new MWArray[]{});
      }


      /// <summary>
      /// Provides the standard 1-input MWArray interface to the projection M-function.
      /// </summary>
      /// <remarks>
      /// </remarks>
      /// <param name="numArgsOut">The number of output arguments to return.</param>
      /// <param name="input">Input argument #1</param>
      /// <returns>An Array of length "numArgsOut" containing the output
      /// arguments.</returns>
      ///
      public MWArray[] projection(int numArgsOut, MWArray input)
      {
          return mcr.EvaluateFunction(numArgsOut, "projection", input);
      }


      /// <summary>
      /// Provides the standard 2-input MWArray interface to the projection M-function.
      /// </summary>
      /// <remarks>
      /// </remarks>
      /// <param name="numArgsOut">The number of output arguments to return.</param>
      /// <param name="input">Input argument #1</param>
      /// <param name="weight">Input argument #2</param>
      /// <returns>An Array of length "numArgsOut" containing the output
      /// arguments.</returns>
      ///
      public MWArray[] projection(int numArgsOut, MWArray input, MWArray weight)
      {
          return mcr.EvaluateFunction(numArgsOut, "projection", input, weight);
      }


      /// <summary>
      /// Provides an interface for the projection function in which the input and output
      /// arguments are specified as an array of MWArrays.
      /// </summary>
      /// <remarks>
      /// This method will allocate and return by reference the output argument
      /// array.<newpara></newpara>
      /// </remarks>
      /// <param name="numArgsOut">The number of output arguments to return</param>
      /// <param name= "argsOut">Array of MWArray output arguments</param>
      /// <param name= "argsIn">Array of MWArray input arguments</param>
      ///
      public void projection(int numArgsOut, ref MWArray[] argsOut, MWArray[] argsIn)
      {
          mcr.EvaluateFunction("projection", numArgsOut, ref argsOut, argsIn);
      }


      /// <summary>
      /// Provides a single output, 0-input MWArray interface to the delete_gallery
      /// M-function.
      /// </summary>
      /// <remarks>
      /// M-Documentation:
      /// find the indexes of the windows that need to be removed
      /// ind will be a vector
      /// </remarks>
      /// <returns>An MWArray containing the first output argument.</returns>
      ///
      public MWArray delete_gallery()
      {
          return mcr.EvaluateFunction("delete_gallery", new MWArray[]{});
      }


      /// <summary>
      /// Provides a single output, 1-input MWArray interface to the delete_gallery
      /// M-function.
      /// </summary>
      /// <remarks>
      /// M-Documentation:
      /// find the indexes of the windows that need to be removed
      /// ind will be a vector
      /// </remarks>
      /// <param name="gal">Input argument #1</param>
      /// <returns>An MWArray containing the first output argument.</returns>
      ///
      public MWArray delete_gallery(MWArray gal)
      {
          return mcr.EvaluateFunction("delete_gallery", gal);
      }


      /// <summary>
      /// Provides a single output, 2-input MWArray interface to the delete_gallery
      /// M-function.
      /// </summary>
      /// <remarks>
      /// M-Documentation:
      /// find the indexes of the windows that need to be removed
      /// ind will be a vector
      /// </remarks>
      /// <param name="gal">Input argument #1</param>
      /// <param name="id">Input argument #2</param>
      /// <returns>An MWArray containing the first output argument.</returns>
      ///
      public MWArray delete_gallery(MWArray gal, MWArray id)
      {
          return mcr.EvaluateFunction("delete_gallery", gal, id);
      }


      /// <summary>
      /// Provides a single output, 3-input MWArray interface to the delete_gallery
      /// M-function.
      /// </summary>
      /// <remarks>
      /// M-Documentation:
      /// find the indexes of the windows that need to be removed
      /// ind will be a vector
      /// </remarks>
      /// <param name="gal">Input argument #1</param>
      /// <param name="id">Input argument #2</param>
      /// <param name="id_num">Input argument #3</param>
      /// <returns>An MWArray containing the first output argument.</returns>
      ///
      public MWArray delete_gallery(MWArray gal, MWArray id, MWArray id_num)
      {
          return mcr.EvaluateFunction("delete_gallery", gal, id, id_num);
      }


      /// <summary>
      /// Provides the standard 0-input MWArray interface to the delete_gallery
      /// M-function.
      /// </summary>
      /// <remarks>
      /// M-Documentation:
      /// find the indexes of the windows that need to be removed
      /// ind will be a vector
      /// </remarks>
      /// <param name="numArgsOut">The number of output arguments to return.</param>
      /// <returns>An Array of length "numArgsOut" containing the output
      /// arguments.</returns>
      ///
      public MWArray[] delete_gallery(int numArgsOut)
      {
          return mcr.EvaluateFunction(numArgsOut,
                                      "delete_gallery", new MWArray[]{});
      }


      /// <summary>
      /// Provides the standard 1-input MWArray interface to the delete_gallery
      /// M-function.
      /// </summary>
      /// <remarks>
      /// M-Documentation:
      /// find the indexes of the windows that need to be removed
      /// ind will be a vector
      /// </remarks>
      /// <param name="numArgsOut">The number of output arguments to return.</param>
      /// <param name="gal">Input argument #1</param>
      /// <returns>An Array of length "numArgsOut" containing the output
      /// arguments.</returns>
      ///
      public MWArray[] delete_gallery(int numArgsOut, MWArray gal)
      {
          return mcr.EvaluateFunction(numArgsOut, "delete_gallery", gal);
      }


      /// <summary>
      /// Provides the standard 2-input MWArray interface to the delete_gallery
      /// M-function.
      /// </summary>
      /// <remarks>
      /// M-Documentation:
      /// find the indexes of the windows that need to be removed
      /// ind will be a vector
      /// </remarks>
      /// <param name="numArgsOut">The number of output arguments to return.</param>
      /// <param name="gal">Input argument #1</param>
      /// <param name="id">Input argument #2</param>
      /// <returns>An Array of length "numArgsOut" containing the output
      /// arguments.</returns>
      ///
      public MWArray[] delete_gallery(int numArgsOut, MWArray gal, MWArray id)
      {
          return mcr.EvaluateFunction(numArgsOut, "delete_gallery", gal, id);
      }


      /// <summary>
      /// Provides the standard 3-input MWArray interface to the delete_gallery
      /// M-function.
      /// </summary>
      /// <remarks>
      /// M-Documentation:
      /// find the indexes of the windows that need to be removed
      /// ind will be a vector
      /// </remarks>
      /// <param name="numArgsOut">The number of output arguments to return.</param>
      /// <param name="gal">Input argument #1</param>
      /// <param name="id">Input argument #2</param>
      /// <param name="id_num">Input argument #3</param>
      /// <returns>An Array of length "numArgsOut" containing the output
      /// arguments.</returns>
      ///
      public MWArray[] delete_gallery(int numArgsOut, MWArray gal,
                                      MWArray id, MWArray id_num)
      {
          return mcr.EvaluateFunction(numArgsOut, "delete_gallery",
                                      gal, id, id_num);
      }


      /// <summary>
      /// Provides an interface for the delete_gallery function in which the input and
      /// output
      /// arguments are specified as an array of MWArrays.
      /// </summary>
      /// <remarks>
      /// This method will allocate and return by reference the output argument
      /// array.<newpara></newpara>
      /// M-Documentation:
      /// find the indexes of the windows that need to be removed
      /// ind will be a vector
      /// </remarks>
      /// <param name="numArgsOut">The number of output arguments to return</param>
      /// <param name= "argsOut">Array of MWArray output arguments</param>
      /// <param name= "argsIn">Array of MWArray input arguments</param>
      ///
      public void delete_gallery(int numArgsOut, ref MWArray[] argsOut,
                           MWArray[] argsIn)
      {
          mcr.EvaluateFunction("delete_gallery", numArgsOut, ref argsOut, argsIn);
      }


      /// <summary>
      /// Provides a single output, 0-input MWArray interface to the delete_id
      /// M-function.
      /// </summary>
      /// <remarks>
      /// M-Documentation:
      /// find the indexes of the windows that need to be removed
      /// ind will be a vector
      /// </remarks>
      /// <returns>An MWArray containing the first output argument.</returns>
      ///
      public MWArray delete_id()
      {
          return mcr.EvaluateFunction("delete_id", new MWArray[]{});
      }


      /// <summary>
      /// Provides a single output, 1-input MWArray interface to the delete_id
      /// M-function.
      /// </summary>
      /// <remarks>
      /// M-Documentation:
      /// find the indexes of the windows that need to be removed
      /// ind will be a vector
      /// </remarks>
      /// <param name="id">Input argument #1</param>
      /// <returns>An MWArray containing the first output argument.</returns>
      ///
      public MWArray delete_id(MWArray id)
      {
          return mcr.EvaluateFunction("delete_id", id);
      }


      /// <summary>
      /// Provides a single output, 2-input MWArray interface to the delete_id
      /// M-function.
      /// </summary>
      /// <remarks>
      /// M-Documentation:
      /// find the indexes of the windows that need to be removed
      /// ind will be a vector
      /// </remarks>
      /// <param name="id">Input argument #1</param>
      /// <param name="id_num">Input argument #2</param>
      /// <returns>An MWArray containing the first output argument.</returns>
      ///
      public MWArray delete_id(MWArray id, MWArray id_num)
      {
          return mcr.EvaluateFunction("delete_id", id, id_num);
      }


      /// <summary>
      /// Provides the standard 0-input MWArray interface to the delete_id M-function.
      /// </summary>
      /// <remarks>
      /// M-Documentation:
      /// find the indexes of the windows that need to be removed
      /// ind will be a vector
      /// </remarks>
      /// <param name="numArgsOut">The number of output arguments to return.</param>
      /// <returns>An Array of length "numArgsOut" containing the output
      /// arguments.</returns>
      ///
      public MWArray[] delete_id(int numArgsOut)
      {
          return mcr.EvaluateFunction(numArgsOut, "delete_id", new MWArray[]{});
      }


      /// <summary>
      /// Provides the standard 1-input MWArray interface to the delete_id M-function.
      /// </summary>
      /// <remarks>
      /// M-Documentation:
      /// find the indexes of the windows that need to be removed
      /// ind will be a vector
      /// </remarks>
      /// <param name="numArgsOut">The number of output arguments to return.</param>
      /// <param name="id">Input argument #1</param>
      /// <returns>An Array of length "numArgsOut" containing the output
      /// arguments.</returns>
      ///
      public MWArray[] delete_id(int numArgsOut, MWArray id)
      {
          return mcr.EvaluateFunction(numArgsOut, "delete_id", id);
      }


      /// <summary>
      /// Provides the standard 2-input MWArray interface to the delete_id M-function.
      /// </summary>
      /// <remarks>
      /// M-Documentation:
      /// find the indexes of the windows that need to be removed
      /// ind will be a vector
      /// </remarks>
      /// <param name="numArgsOut">The number of output arguments to return.</param>
      /// <param name="id">Input argument #1</param>
      /// <param name="id_num">Input argument #2</param>
      /// <returns>An Array of length "numArgsOut" containing the output
      /// arguments.</returns>
      ///
      public MWArray[] delete_id(int numArgsOut, MWArray id, MWArray id_num)
      {
          return mcr.EvaluateFunction(numArgsOut, "delete_id", id, id_num);
      }


      /// <summary>
      /// Provides an interface for the delete_id function in which the input and output
      /// arguments are specified as an array of MWArrays.
      /// </summary>
      /// <remarks>
      /// This method will allocate and return by reference the output argument
      /// array.<newpara></newpara>
      /// M-Documentation:
      /// find the indexes of the windows that need to be removed
      /// ind will be a vector
      /// </remarks>
      /// <param name="numArgsOut">The number of output arguments to return</param>
      /// <param name= "argsOut">Array of MWArray output arguments</param>
      /// <param name= "argsIn">Array of MWArray input arguments</param>
      ///
      public void delete_id(int numArgsOut, ref MWArray[] argsOut, MWArray[] argsIn)
      {
          mcr.EvaluateFunction("delete_id", numArgsOut, ref argsOut, argsIn);
      }


      /// <summary>
      /// Provides a single output, 0-input MWArray interface to the authentication
      /// M-function.
      /// </summary>
      /// <remarks>
      /// M-Documentation:
      /// input: user's input (LDA projected)  this is 1xn
      /// gallery : Claimed record (LDA projected)    mxn   where m is the # of
      /// windows in the gallery for this subject and n the dimensionality after
      /// lda
      /// </remarks>
      /// <returns>An MWArray containing the first output argument.</returns>
      ///
      public MWArray authentication()
      {
          return mcr.EvaluateFunction("authentication", new MWArray[]{});
      }


      /// <summary>
      /// Provides a single output, 1-input MWArray interface to the authentication
      /// M-function.
      /// </summary>
      /// <remarks>
      /// M-Documentation:
      /// input: user's input (LDA projected)  this is 1xn
      /// gallery : Claimed record (LDA projected)    mxn   where m is the # of
      /// windows in the gallery for this subject and n the dimensionality after
      /// lda
      /// </remarks>
      /// <param name="input">Input argument #1</param>
      /// <returns>An MWArray containing the first output argument.</returns>
      ///
      public MWArray authentication(MWArray input)
      {
          return mcr.EvaluateFunction("authentication", input);
      }


      /// <summary>
      /// Provides a single output, 2-input MWArray interface to the authentication
      /// M-function.
      /// </summary>
      /// <remarks>
      /// M-Documentation:
      /// input: user's input (LDA projected)  this is 1xn
      /// gallery : Claimed record (LDA projected)    mxn   where m is the # of
      /// windows in the gallery for this subject and n the dimensionality after
      /// lda
      /// </remarks>
      /// <param name="input">Input argument #1</param>
      /// <param name="gallery">Input argument #2</param>
      /// <returns>An MWArray containing the first output argument.</returns>
      ///
      public MWArray authentication(MWArray input, MWArray gallery)
      {
          return mcr.EvaluateFunction("authentication", input, gallery);
      }


      /// <summary>
      /// Provides a single output, 3-input MWArray interface to the authentication
      /// M-function.
      /// </summary>
      /// <remarks>
      /// M-Documentation:
      /// input: user's input (LDA projected)  this is 1xn
      /// gallery : Claimed record (LDA projected)    mxn   where m is the # of
      /// windows in the gallery for this subject and n the dimensionality after
      /// lda
      /// </remarks>
      /// <param name="input">Input argument #1</param>
      /// <param name="gallery">Input argument #2</param>
      /// <param name="thresh">Input argument #3</param>
      /// <returns>An MWArray containing the first output argument.</returns>
      ///
      public MWArray authentication(MWArray input, MWArray gallery,
                                    MWArray thresh)
      {
          return mcr.EvaluateFunction("authentication", input, gallery, thresh);
      }


      /// <summary>
      /// Provides the standard 0-input MWArray interface to the authentication
      /// M-function.
      /// </summary>
      /// <remarks>
      /// M-Documentation:
      /// input: user's input (LDA projected)  this is 1xn
      /// gallery : Claimed record (LDA projected)    mxn   where m is the # of
      /// windows in the gallery for this subject and n the dimensionality after
      /// lda
      /// </remarks>
      /// <param name="numArgsOut">The number of output arguments to return.</param>
      /// <returns>An Array of length "numArgsOut" containing the output
      /// arguments.</returns>
      ///
      public MWArray[] authentication(int numArgsOut)
      {
          return mcr.EvaluateFunction(numArgsOut,
                                      "authentication", new MWArray[]{});
      }


      /// <summary>
      /// Provides the standard 1-input MWArray interface to the authentication
      /// M-function.
      /// </summary>
      /// <remarks>
      /// M-Documentation:
      /// input: user's input (LDA projected)  this is 1xn
      /// gallery : Claimed record (LDA projected)    mxn   where m is the # of
      /// windows in the gallery for this subject and n the dimensionality after
      /// lda
      /// </remarks>
      /// <param name="numArgsOut">The number of output arguments to return.</param>
      /// <param name="input">Input argument #1</param>
      /// <returns>An Array of length "numArgsOut" containing the output
      /// arguments.</returns>
      ///
      public MWArray[] authentication(int numArgsOut, MWArray input)
      {
          return mcr.EvaluateFunction(numArgsOut, "authentication", input);
      }


      /// <summary>
      /// Provides the standard 2-input MWArray interface to the authentication
      /// M-function.
      /// </summary>
      /// <remarks>
      /// M-Documentation:
      /// input: user's input (LDA projected)  this is 1xn
      /// gallery : Claimed record (LDA projected)    mxn   where m is the # of
      /// windows in the gallery for this subject and n the dimensionality after
      /// lda
      /// </remarks>
      /// <param name="numArgsOut">The number of output arguments to return.</param>
      /// <param name="input">Input argument #1</param>
      /// <param name="gallery">Input argument #2</param>
      /// <returns>An Array of length "numArgsOut" containing the output
      /// arguments.</returns>
      ///
      public MWArray[] authentication(int numArgsOut, MWArray input,
                                      MWArray gallery)
      {
          return mcr.EvaluateFunction(numArgsOut, "authentication",
                                      input, gallery);
      }


      /// <summary>
      /// Provides the standard 3-input MWArray interface to the authentication
      /// M-function.
      /// </summary>
      /// <remarks>
      /// M-Documentation:
      /// input: user's input (LDA projected)  this is 1xn
      /// gallery : Claimed record (LDA projected)    mxn   where m is the # of
      /// windows in the gallery for this subject and n the dimensionality after
      /// lda
      /// </remarks>
      /// <param name="numArgsOut">The number of output arguments to return.</param>
      /// <param name="input">Input argument #1</param>
      /// <param name="gallery">Input argument #2</param>
      /// <param name="thresh">Input argument #3</param>
      /// <returns>An Array of length "numArgsOut" containing the output
      /// arguments.</returns>
      ///
      public MWArray[] authentication(int numArgsOut, MWArray input,
                                      MWArray gallery, MWArray thresh)
      {
          return mcr.EvaluateFunction(numArgsOut, "authentication",
                                      input, gallery, thresh);
      }


      /// <summary>
      /// Provides an interface for the authentication function in which the input and
      /// output
      /// arguments are specified as an array of MWArrays.
      /// </summary>
      /// <remarks>
      /// This method will allocate and return by reference the output argument
      /// array.<newpara></newpara>
      /// M-Documentation:
      /// input: user's input (LDA projected)  this is 1xn
      /// gallery : Claimed record (LDA projected)    mxn   where m is the # of
      /// windows in the gallery for this subject and n the dimensionality after
      /// lda
      /// </remarks>
      /// <param name="numArgsOut">The number of output arguments to return</param>
      /// <param name= "argsOut">Array of MWArray output arguments</param>
      /// <param name= "argsIn">Array of MWArray input arguments</param>
      ///
      public void authentication(int numArgsOut, ref MWArray[] argsOut,
                           MWArray[] argsIn)
      {
          mcr.EvaluateFunction("authentication", numArgsOut, ref argsOut, argsIn);
      }


      /// <summary>
      /// Provides a single output, 0-input MWArray interface to the claim_gallery
      /// M-function.
      /// </summary>
      /// <remarks>
      /// </remarks>
      /// <returns>An MWArray containing the first output argument.</returns>
      ///
      public MWArray claim_gallery()
      {
          return mcr.EvaluateFunction("claim_gallery", new MWArray[]{});
      }


      /// <summary>
      /// Provides a single output, 1-input MWArray interface to the claim_gallery
      /// M-function.
      /// </summary>
      /// <remarks>
      /// </remarks>
      /// <param name="gallery">Input argument #1</param>
      /// <returns>An MWArray containing the first output argument.</returns>
      ///
      public MWArray claim_gallery(MWArray gallery)
      {
          return mcr.EvaluateFunction("claim_gallery", gallery);
      }


      /// <summary>
      /// Provides a single output, 2-input MWArray interface to the claim_gallery
      /// M-function.
      /// </summary>
      /// <remarks>
      /// </remarks>
      /// <param name="gallery">Input argument #1</param>
      /// <param name="id">Input argument #2</param>
      /// <returns>An MWArray containing the first output argument.</returns>
      ///
      public MWArray claim_gallery(MWArray gallery, MWArray id)
      {
          return mcr.EvaluateFunction("claim_gallery", gallery, id);
      }


      /// <summary>
      /// Provides a single output, 3-input MWArray interface to the claim_gallery
      /// M-function.
      /// </summary>
      /// <remarks>
      /// </remarks>
      /// <param name="gallery">Input argument #1</param>
      /// <param name="id">Input argument #2</param>
      /// <param name="id_num">Input argument #3</param>
      /// <returns>An MWArray containing the first output argument.</returns>
      ///
      public MWArray claim_gallery(MWArray gallery, MWArray id, MWArray id_num)
      {
          return mcr.EvaluateFunction("claim_gallery", gallery, id, id_num);
      }


      /// <summary>
      /// Provides the standard 0-input MWArray interface to the claim_gallery
      /// M-function.
      /// </summary>
      /// <remarks>
      /// </remarks>
      /// <param name="numArgsOut">The number of output arguments to return.</param>
      /// <returns>An Array of length "numArgsOut" containing the output
      /// arguments.</returns>
      ///
      public MWArray[] claim_gallery(int numArgsOut)
      {
          return mcr.EvaluateFunction(numArgsOut,
                                      "claim_gallery", new MWArray[]{});
      }


      /// <summary>
      /// Provides the standard 1-input MWArray interface to the claim_gallery
      /// M-function.
      /// </summary>
      /// <remarks>
      /// </remarks>
      /// <param name="numArgsOut">The number of output arguments to return.</param>
      /// <param name="gallery">Input argument #1</param>
      /// <returns>An Array of length "numArgsOut" containing the output
      /// arguments.</returns>
      ///
      public MWArray[] claim_gallery(int numArgsOut, MWArray gallery)
      {
          return mcr.EvaluateFunction(numArgsOut, "claim_gallery", gallery);
      }


      /// <summary>
      /// Provides the standard 2-input MWArray interface to the claim_gallery
      /// M-function.
      /// </summary>
      /// <remarks>
      /// </remarks>
      /// <param name="numArgsOut">The number of output arguments to return.</param>
      /// <param name="gallery">Input argument #1</param>
      /// <param name="id">Input argument #2</param>
      /// <returns>An Array of length "numArgsOut" containing the output
      /// arguments.</returns>
      ///
      public MWArray[] claim_gallery(int numArgsOut,
                                     MWArray gallery, MWArray id)
      {
          return mcr.EvaluateFunction(numArgsOut, "claim_gallery", gallery, id);
      }


      /// <summary>
      /// Provides the standard 3-input MWArray interface to the claim_gallery
      /// M-function.
      /// </summary>
      /// <remarks>
      /// </remarks>
      /// <param name="numArgsOut">The number of output arguments to return.</param>
      /// <param name="gallery">Input argument #1</param>
      /// <param name="id">Input argument #2</param>
      /// <param name="id_num">Input argument #3</param>
      /// <returns>An Array of length "numArgsOut" containing the output
      /// arguments.</returns>
      ///
      public MWArray[] claim_gallery(int numArgsOut, MWArray gallery,
                                     MWArray id, MWArray id_num)
      {
          return mcr.EvaluateFunction(numArgsOut, "claim_gallery",
                                      gallery, id, id_num);
      }


      /// <summary>
      /// Provides an interface for the claim_gallery function in which the input and
      /// output
      /// arguments are specified as an array of MWArrays.
      /// </summary>
      /// <remarks>
      /// This method will allocate and return by reference the output argument
      /// array.<newpara></newpara>
      /// </remarks>
      /// <param name="numArgsOut">The number of output arguments to return</param>
      /// <param name= "argsOut">Array of MWArray output arguments</param>
      /// <param name= "argsIn">Array of MWArray input arguments</param>
      ///
      public void claim_gallery(int numArgsOut, ref MWArray[] argsOut,
                          MWArray[] argsIn)
      {
          mcr.EvaluateFunction("claim_gallery", numArgsOut, ref argsOut, argsIn);
      }


      /// <summary>
      /// This method will cause a MATLAB figure window to behave as a modal dialog box.
      /// The method will not return until all the figure windows associated with this
      /// component have been closed.
      /// </summary>
      /// <remarks>
      /// An application should only call this method when required to keep the
      /// MATLAB figure window from disappearing.  Other techniques, such as calling
      /// Console.ReadLine() from the application should be considered where
      /// possible.</remarks>
      ///
      public void WaitForFiguresToDie()
      {
          mcr.WaitForFiguresToDie();
      }


      
      #endregion Methods

      #region Class Members

      private static MWMCR mcr= null;

      private bool disposed= false;

      #endregion Class Members
  }
}
