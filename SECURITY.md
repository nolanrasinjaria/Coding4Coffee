# Security Policy for Unsafe Code

## Overview

This project uses `<AllowUnsafeBlocks>true</AllowUnsafeBlocks>` in the `Coding4Coffee.WinForms` project exclusively for P/Invoke interoperability with Windows APIs via `LibraryImport` attributes.

## Policy

### ✅ ALLOWED

1. **LibraryImport for Native APIs**
   - Using `[LibraryImport]` to call Windows OS functions
   - Example: `ShowContextHelpCommand.cs` → `user32.dll` interop
   - Rationale: Compiler-generated, verifiable, necessary for Windows integration

2. **Managed Wrappers of LibraryImport**
   - Wrapping native calls in safe managed methods
   - Returning only managed types (strings, objects, etc.)
   - Example: `SendMessage()` private method returning `IntPtr`

### ❌ STRICTLY FORBIDDEN

1. **Custom `unsafe` Blocks**
   - Direct pointer arithmetic
   - Manual memory allocation via `Marshal.AllocHGlobal()`
   - Buffer operations without bounds checking
   - Stack-based pointers to managed objects

   Example of forbidden pattern:
   ```csharp
   ❌ unsafe void BadCode() {
	   int* ptr = null;
	   *ptr = 42;  // Crash!
   }
   ```

2. **Mixing safe and unsafe APIs**
   - Casting managed objects to pointers
   - Bypassing type safety
   - Ignoring GC lifetime guarantees

## Code Review Requirements

Any pull request touching unsafe code must:

1. ✅ **Justify the need**
   - Why can't we use safe managed APIs?
   - What Windows API is required?

2. ✅ **Use LibraryImport only**
   - No legacy `DllImport` patterns
   - No custom `unsafe` keyword except in generated code

3. ✅ **Document the intent**
   - XML comments explaining the native call
   - Link to relevant Windows API documentation
   - Example:
	 ```csharp
	 /// <summary>
	 /// Sends a message to the specified window.
	 /// </summary>
	 /// <remarks>
	 /// Wraps Windows API: https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-sendmessage
	 /// Only used internally by ShowContextHelpCommand for context help integration.
	 /// </remarks>
	 [LibraryImport("user32.dll", SetLastError = true, StringMarshalling = StringMarshalling.Utf16)]
	 private static partial IntPtr SendMessage(IntPtr hWnd, int msg, IntPtr wParam, IntPtr lParam);
	 ```

4. ✅ **Test thoroughly**
   - Windows platform only
   - Handle null/invalid parameters gracefully
   - No memory leaks (use `using` where applicable)

5. ✅ **Seal wrapper classes**
   - Unsafe wrappers should be `sealed` to prevent unsafe subclassing
   - Example: `public sealed class ShowContextHelpCommand`

## Building Without Unsafe Blocks

If you want to disable unsafe code in development:

```bash
# Temporary override (for testing only)
dotnet build /p:AllowUnsafeBlocks=false Coding4Coffee.WinForms
```

## Reporting Security Issues

If you discover unsafe code usage that doesn't follow this policy, **do not open a public issue**. Instead:

1. Email security concerns to the maintainers
2. Include reproduction steps
3. Do not disclose details publicly until patched

## References

- [Microsoft: unsafe keyword documentation](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/unsafe)
- [Microsoft: LibraryImport instead of DllImport](https://learn.microsoft.com/en-us/dotnet/standard/native-interop/pinvoke)
- [OWASP: Memory Safety](https://owasp.org/www-community/attacks/Memory_Safety)

---

**Last Updated:** .NET 10  
**Policy Version:** 1.0
