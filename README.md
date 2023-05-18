# CustomExplorer-Multi-Threading

Task
It is necessary to develop an application for Windows OS that allows you to recursively enumerate 
all nested subdirectories and files for the specified directory, saving the results to a file in XML format.
Specification
1. For each subdirectory and file, the XML file must contain: 
name, creation date, modification date, last access date, attributes, 
size (for files only), 
the owner, and allowed permissions (write, read, delete, and etc.) for the current user.
2. In addition to placing the results in a file, they must also be entered in a visual control element - a tree, 
which must be placed on the main application window.
3. The application must be organized in the form of four threads that run in parallel:
• "main" (Application.Run());
• "information collection flow" (performs scanning of the specified directory and is created only on
scan time)
• "flow of entering results into XML-file" (receives from the "flow of information collection" information about
next subdirectory or file and enters this information into an XML file);
• “thread for adding results to the tree” (receives information about the next subdirectory or file from 
the “information collection flow” and enters this information into the tree control element);
4. Synchronization between threads should be done using underlying mechanisms provided by the platform, such as Monitor, 
types derived from WaitHandle, etc. Not recommended to use high-level mechanisms provided by the so-called
 TPLs such as BlockingCollection, various Concurrent* collections.
5. The choice of the directory and the indication of the location of the result file must be carried out 
using the graphical user interface.
6. Particular attention should be paid to handling possible run-time errors and notifying the user about them.