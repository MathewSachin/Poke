# Add project specific ProGuard rules here.
# By default, the flags in this file are applied to all builds.

# Kotlin serialization
-keepattributes *Annotation*, InnerClasses
-dontnote kotlinx.serialization.AnnotationsKt
