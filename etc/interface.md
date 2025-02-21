class User:
    def __init__(self, name: str, email: str):
        self.name = name
        self.email = email
        
class Database:
    def save_to_database(self):
        """Saves user information to the database (simulated with a print statement)."""
        print(f"Saving {self.name} to the database...")

class Write:
    def format_report(self):
        """Formats the user data as a report."""
        return f"User Report:\nName: {self.name}\nEmail: {self.email}
    def send_email(self, message: str):
        """Simulates sending an email to the user."""
        print(f"Sending email to {self.email}:\n{message}")
**Questions**
- The benefits of refactoring code to use SRP is that it makes our code less prone to errors as we make modifications.
- The new design refactors the code so that each class doesn't hold too much responsibility. The it User class and responsible creating users, the Database class is solely responsible for saving information to itself, and the Write class is responsible for anything related to writing text.
- Because the code uses the SRP principle, even if we decided to swap databases, it would not matter because each class only relies on itself. If we weren't using SRP, then this would be an issue.

**Part 2** 
        class Player:
         pass

       class Enemy:
          pass

        class Map:
          pass
