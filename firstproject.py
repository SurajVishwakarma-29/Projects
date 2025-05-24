import tkinter as tk
from tkinter import messagebox
import mysql.connector


def connect_db():
    try:
        return mysql.connector.connect(
            host="localhost",
            user="root",
            password="your_password",  # Replace with your MySQL root password
            database="your_database"  # Replace with your database name
        )
    except mysql.connector.Error as err:
        messagebox.showerror("Error", f"Error connecting to MySQL: {err}")
        return None


def create_table():
    conn = connect_db()
    if conn:
        cursor = conn.cursor()
        cursor.execute('''
            CREATE TABLE IF NOT EXISTS employees (
                id INT AUTO_INCREMENT PRIMARY KEY,
                name VARCHAR(255) NOT NULL,
                designation VARCHAR(255) NOT NULL,
                salary DECIMAL(10, 2) NOT NULL
            )
        ''')
        conn.commit()
        conn.close()


def check_login():
    username = entry_username.get()
    password = entry_password.get()

    if username == "admin" and password == "admin123":
        login_window.destroy()
        open_main_window()
    else:
        messagebox.showerror("Login Failed", "Invalid username or password!")


def open_main_window():
    global root
    root = tk.Tk()
    root.title("Finance Employee Management")
    root.geometry("500x500")
    root.configure(bg="#f0f4f8")

    header = tk.Label(root, text="👨‍💼 Finance Employee Management", font=("Helvetica", 18, "bold"),
                      bg="#0984e3", fg="white", pady=20)
    header.pack(fill=tk.X)

    btn_frame = tk.Frame(root, bg="#f0f4f8")
    btn_frame.pack(pady=40)

    button_style = {
        "font": ("Arial", 13, "bold"),
        "width": 25,
        "bg": "#74b9ff",
        "fg": "white",
        "activebackground": "#0984e3",
        "bd": 0,
        "pady": 10
    }

    tk.Button(btn_frame, text="➕ Insert Employee", command=open_insert_form, **button_style).pack(pady=10)
    tk.Button(btn_frame, text="✏️ Update Employee", command=open_update_form, **button_style).pack(pady=10)
    tk.Button(btn_frame, text="❌ Delete Employee", command=open_delete_form, **button_style).pack(pady=10)
    tk.Button(btn_frame, text="📋 Display All Employees", command=open_display_form, **button_style).pack(pady=10)

    tk.Label(root, text="© 2025 Finance HR System", font=("Arial", 10), bg="#f0f4f8", fg="gray").pack(side=tk.BOTTOM, pady=20)

    create_table()
    root.mainloop()


def open_insert_form():
    def insert_employee():
        name = entry_name.get()
        designation = entry_designation.get()
        salary = entry_salary.get()

        if not name or not designation or not salary:
            messagebox.showwarning("Input Error", "All fields are required")
            return

        try:
            salary = float(salary)
            conn = connect_db()
            if conn:
                cursor = conn.cursor()
                cursor.execute("INSERT INTO employees (name, designation, salary) VALUES (%s, %s, %s)",
                               (name, designation, salary))
                conn.commit()
                conn.close()
                messagebox.showinfo("Success", "Employee inserted successfully!")
                window.destroy()
        except Exception as e:
            messagebox.showerror("Error", f"Error: {e}")

    window = tk.Toplevel(root)
    window.title("Insert Employee")
    window.geometry("300x250")

    tk.Label(window, text="Name:").grid(row=0, column=0, padx=10, pady=5)
    entry_name = tk.Entry(window)
    entry_name.grid(row=0, column=1)

    tk.Label(window, text="Designation:").grid(row=1, column=0, padx=10, pady=5)
    entry_designation = tk.Entry(window)
    entry_designation.grid(row=1, column=1)

    tk.Label(window, text="Salary:").grid(row=2, column=0, padx=10, pady=5)
    entry_salary = tk.Entry(window)
    entry_salary.grid(row=2, column=1)

    tk.Button(window, text="Insert", command=insert_employee).grid(row=3, columnspan=2, pady=10)
    tk.Button(window, text="Back", command=window.destroy).grid(row=4, columnspan=2, pady=5)

# --- Update Employee Form ---
def open_update_form():
    def update_employee():
        try:
            salary = float(entry_salary.get())
            conn = connect_db()
            if conn:
                cursor = conn.cursor()
                cursor.execute("UPDATE employees SET name=%s, designation=%s, salary=%s WHERE id=%s",
                               (entry_name.get(), entry_designation.get(), salary, entry_id.get()))
                conn.commit()
                conn.close()
                messagebox.showinfo("Success", "Employee updated successfully!")
                window.destroy()
        except Exception as e:
            messagebox.showerror("Error", f"Error: {e}")

    window = tk.Toplevel(root)
    window.title("Update Employee")
    window.geometry("300x300")

    tk.Label(window, text="ID:").grid(row=0, column=0, padx=10, pady=5)
    entry_id = tk.Entry(window)
    entry_id.grid(row=0, column=1)

    tk.Label(window, text="Name:").grid(row=1, column=0, padx=10, pady=5)
    entry_name = tk.Entry(window)
    entry_name.grid(row=1, column=1)

    tk.Label(window, text="Designation:").grid(row=2, column=0, padx=10, pady=5)
    entry_designation = tk.Entry(window)
    entry_designation.grid(row=2, column=1)

    tk.Label(window, text="Salary:").grid(row=3, column=0, padx=10, pady=5)
    entry_salary = tk.Entry(window)
    entry_salary.grid(row=3, column=1)

    tk.Button(window, text="Update", command=update_employee).grid(row=4, columnspan=2, pady=10)
    tk.Button(window, text="Back", command=window.destroy).grid(row=5, columnspan=2, pady=5)

def open_delete_form():
    def delete_employee():
        emp_id = entry_id.get()
        if not emp_id:
            messagebox.showwarning("Input Error", "Employee ID is required")
            return
        try:
            conn = connect_db()
            if conn:
                cursor = conn.cursor()
                cursor.execute("DELETE FROM employees WHERE id = %s", (emp_id,))
                conn.commit()
                conn.close()
                messagebox.showinfo("Success", "Employee deleted successfully!")
                window.destroy()
        except Exception as e:
            messagebox.showerror("Error", f"Error: {e}")

    window = tk.Toplevel(root)
    window.title("Delete Employee")
    window.geometry("250x150")

    tk.Label(window, text="Employee ID:").grid(row=0, column=0, padx=10, pady=10)
    entry_id = tk.Entry(window)
    entry_id.grid(row=0, column=1)

    tk.Button(window, text="Delete", command=delete_employee).grid(row=1, columnspan=2, pady=10)
    tk.Button(window, text="Back", command=window.destroy).grid(row=2, columnspan=2, pady=5)

# --- Display Employees ---
def open_display_form():
    window = tk.Toplevel(root)
    window.title("All Employees")
    window.geometry("500x350")

    text_area = tk.Text(window, wrap=tk.WORD, font=("Arial", 10))
    text_area.pack(padx=10, pady=10, fill=tk.BOTH, expand=True)

    tk.Button(window, text="Back", command=window.destroy).pack(pady=5)

    try:
        conn = connect_db()
        if conn:
            cursor = conn.cursor()
            cursor.execute("SELECT * FROM employees")
            for row in cursor.fetchall():
                text_area.insert(tk.END, f"ID: {row[0]}, Name: {row[1]}, Designation: {row[2]}, Salary: {row[3]:.2f}\n")
            conn.close()
    except Exception as e:
        messagebox.showerror("Error", f"Error: {e}")

# --- Login UI ---
login_window = tk.Tk()
login_window.title("Login - Finance HR")
login_window.geometry("350x250")
login_window.configure(bg="#dfe6e9")

tk.Label(login_window, text="🔐 Login", font=("Helvetica", 18, "bold"), bg="#0984e3", fg="white", pady=10).pack(fill=tk.X)

tk.Label(login_window, text="Username:", font=("Arial", 12), bg="#dfe6e9").pack(pady=(20, 5))
entry_username = tk.Entry(login_window, font=("Arial", 12))
entry_username.pack()

tk.Label(login_window, text="Password:", font=("Arial", 12), bg="#dfe6e9").pack(pady=(10, 5))
entry_password = tk.Entry(login_window, show="*", font=("Arial", 12))
entry_password.pack()

tk.Button(login_window, text="Login", command=check_login,
          font=("Arial", 12, "bold"), bg="#00b894", fg="white", width=15).pack(pady=20)

tk.Label(login_window, text="Use admin / admin123", font=("Arial", 9), bg="#dfe6e9", fg="gray").pack()

login_window.mainloop()
