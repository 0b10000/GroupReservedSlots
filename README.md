# GroupReservedSlots
*I did it, mom! I patched preauth!*

This EXILED plugin automatically gives groups that you specify a reserved slot on your server. It also respects the reserved slot file, if you want to use that too.

## Configs
```yml
GroupReservedSlots:
# Whether or not this plugin is enabled.
  is_enabled: true
  # Group names that should get reserved slots
  reserved_groups:
  - owner
  - admin
  - moderator
  - donator
  debug: false
```
Be careful to use the *group name*, not the tag text. If you need help getting your tag names, simply turn on `debug` in order to get a helpful debug message on what your tag is and whether you will have a reserved slot.
For example:

```[DEBUG] [GroupReservedSlots] [REDACTED]@steam: owner | True```

`owner` is the group, and `True` indicates that players in the `owner` group get a reserved slot (or have a reserved slot in the reserved slots file).
