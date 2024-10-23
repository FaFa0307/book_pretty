using System;
using System.IO;
using System.Text.RegularExpressions;

public class Validator
{
    private static string filename;
    private static string passwordError;
    private static string fileError;
    private static string searchError;

    // Métodos para obtener errores o el nombre del archivo validado.
    public static string GetPasswordError() => passwordError;
    public static string GetFileError() => fileError;
    public static string GetFilename() => filename;
    public static string GetSearchError() => searchError;

    // Validar un número natural (mayor o igual a 1).
    public static bool ValidateNaturalNumber(string value)
    {
        if (int.TryParse(value, out int result) && result >= 1)
        {
            return true;
        }
        return false;
    }


    public static bool ValidateDecimalNumber(string value)
    {
        // Intenta convertir la cadena a un decimal
        if (decimal.TryParse(value, out decimal result) && result >= 0)
        {
            return true;
        }
        return false; // Retorna false si no se puede convertir o si es menor a 0
    }


    // Validar un archivo de imagen.
    public static bool ValidateImageFile(string filePath, int dimension)
    {
        if (File.Exists(filePath))
        {
            var image = System.Drawing.Image.FromFile(filePath);
            if (new FileInfo(filePath).Length > 2097152)
            {
                fileError = "El tamaño de la imagen debe ser menor a 2MB";
                return false;
            }
            else if (image.Width < dimension)
            {
                fileError = $"La dimensión de la imagen es menor a {dimension}px";
                return false;
            }
            else if (image.Width != image.Height)
            {
                fileError = "La imagen no es cuadrada";
                return false;
            }
            else if (Path.GetExtension(filePath).ToLower() == ".jpg" || Path.GetExtension(filePath).ToLower() == ".png")
            {
                filename = Guid.NewGuid().ToString() + Path.GetExtension(filePath).ToLower();
                return true;
            }
            else
            {
                fileError = "El tipo de imagen debe ser jpg o png";
                return false;
            }
        }
        return false;
    }

    // Validar un correo electrónico.
    public static bool ValidateEmail(string value)
    {
        return Regex.IsMatch(value, @"^[^@\s]+@[^@\s]+\.[^@\s]+$");
    }

    // Validar una cadena alfabética.
    public static bool ValidateAlphabetic(string value)
    {
        return Regex.IsMatch(value, @"^[a-zA-ZñÑáÁéÉíÍóÓúÚ\s]+$");
    }

    // Validar una contraseña (longitud mínima de 8 caracteres).
    public static bool ValidatePassword(string value)
    {
        if (value.Length < 8)
        {
            passwordError = "La contraseña es menor a 8 caracteres";
            return false;
        }
        return true;
    }

    // Validar un archivo al guardarlo en una ruta.
    public static bool SaveFile(string sourceFilePath, string destinationDirectory)
    {
        try
        {
            if (!File.Exists(sourceFilePath)) return false;

            var destinationPath = Path.Combine(destinationDirectory, filename);
            File.Copy(sourceFilePath, destinationPath);
            return true;
        }
        catch
        {
            return false;
        }
    }

    // Validar un número telefónico (formato de El Salvador: 8 dígitos, empezando por 6 o 7).
    public static bool ValidatePhoneNumber(string value)
    {
        return Regex.IsMatch(value, @"^[67]\d{7}$");
    }

    // Validar una cadena alfanumérica.
    public static bool ValidateAlphanumeric(string value)
    {
        return Regex.IsMatch(value, @"^[a-zA-Z0-9ñÑáÁéÉíÍóÓúÚ\s]+$");
    }

    // Validar una fecha en formato dd/mm/yyyy.
    public static bool ValidateDate(string value)
    {
        return DateTime.TryParseExact(value, "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out _);
    }

    //Validar el actualizar fecha que no sea a una pasada de la origina y de la actual
    public static bool ValidateFutureDate(DateTime fechaOriginal, string nuevaFechaValor)
    {
        // Intentar convertir la cadena nueva a DateTime
        if (DateTime.TryParseExact(nuevaFechaValor, "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out DateTime nuevaFecha))
        {
            DateTime fechaActual = DateTime.Now; // Obtener la fecha actual

            // Verifica si la nueva fecha es mayor al año actual
            if (nuevaFecha.Year > fechaActual.Year)
            {
                return false; // No permitir fechas de un año mayor al actual
            }

            // Comparar la nueva fecha con la fecha original
            return nuevaFecha >= fechaOriginal && nuevaFecha <= new DateTime(fechaActual.Year, 12, 31); // No permitir fechas mayores al 31 de diciembre del año actual
        }

        return false; // Si no se puede convertir la cadena a una fecha, retornar false
    }





    // Cambiar un archivo (eliminar el antiguo y guardar uno nuevo).
    public static bool ChangeFile(string oldFilePath, string newFilePath, string destinationDirectory)
    {
        try
        {
            if (File.Exists(oldFilePath))
            {
                File.Delete(oldFilePath); // Elimina el archivo antiguo
            }
            return SaveFile(newFilePath, destinationDirectory); // Guarda el nuevo archivo
        }
        catch
        {
            return false;
        }
    }

    // Eliminar un archivo.
    public static bool DeleteFile(string filePath)
    {
        try
        {
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
                return true;
            }
            return false;
        }
        catch
        {
            return false;
        }
    }

    // Validar una cadena de búsqueda (alfa y espacios).
    public static bool ValidateSearch(string value)
    {
        if (value.Length < 1)
        {
            searchError = "Debe escribir una palabra de búsqueda.";
            return false;
        }
        return Regex.IsMatch(value, @"^[a-zA-ZñÑáÁéÉíÍóÓúÚ\s]+$");
    }
}