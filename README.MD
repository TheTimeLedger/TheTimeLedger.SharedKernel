# TheTimeLedger.SharedKernel

Shared domain primitives for the TheTimeLedger ecosystem.

This package provides a minimal set of stable building blocks used across bounded contexts,
including entities, aggregate roots, and domain events.

The SharedKernel is intentionally domain-agnostic and contains no business rules.
Its purpose is to support clear boundaries, explicit contracts, and long-term evolution
through versioned packages.