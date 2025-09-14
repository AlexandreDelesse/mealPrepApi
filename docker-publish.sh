#!/usr/bin/env bash
set -e

# Usage: ./build-push.sh <environment>
ENV="$1"

if [ -z "$ENV" ]; then
  echo "Usage: $0 <environment>"
  exit 1
fi

ORG="UrgenceSante"   # <== ton compte ou ton organisation Docker Hub en dur
IMAGE="${ORG}/mealAppApi-${ENV}"

echo "==> Build $IMAGE"
docker build -t "$IMAGE" .

echo "==> Push $IMAGE"
docker push "$IMAGE"

echo "✅ Image disponible sur Docker Hub : $IMAGE"
