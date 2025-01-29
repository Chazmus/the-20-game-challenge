# An attempt at the 20 games challenge

Link to challenge: https://20_games_challenge.gitlab.io/

Using Godot and C# to try and push my skills will (maybe) add random notes and insights to this README as I discover them.

## Random Notes and Insights

Don't set `Position` on `RigidBody2D` turns out they are made to be interacted with like physic objects, setting things like velocity and applying forces etc. If you do set the Position - any collider child does not get moved!
This is obvious from the docs, I should've read the docs. https://docs.godotengine.org/en/stable/classes/class_rigidbody2d.html
